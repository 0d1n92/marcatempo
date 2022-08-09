
using api.Helpers;
using api.Interface;
using api.Model.Entity;
using api.DTOs;
using System.Collections.Generic;
using System.Linq;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using api.Extensions;
using Microsoft.AspNetCore.Http;
using System.IO;
using api.Utilitis.Enum;

namespace api.Services
{
    public class UsersService : IUsersService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;

        public UsersService(
            DataContext context,
            IJwtUtils jwtUtils
            )
        {
            _context = context;
            _jwtUtils = jwtUtils;
        }

        public async Task<(bool Success, string Token)> Authenticate(AuthenticateRequestDto model)
        {
            try
            {
                var user = await _context.Users.Include(x => x.Role).SingleOrDefaultAsync(x => x.Username == model.Username);
                if (user != null || user != null ? BCryptNet.Verify(model.Password, user.Password) : false)
                {
                    return (true, _jwtUtils.GenerateToken(user));
                }
                 return (false, "User not found");
            } catch(Exception ex)
            {
                return (false,ex.Message);
            }
        }

        private User getUser(int id)
        {
            var user = _context.Users.Include(x => x.Role).Where( x => x.Id == id).First();
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public async Task<(bool Success, string Message)> Register(RegisterRequestDto model, QRcode qrcode, User user)
        {

            if (_context.Users.Any(x => x.Username == model.Username))
                return (false, "Username already taken");

            user.Password = BCryptNet.HashPassword(model.Password);
            _context.Users.Add(user);
           

            if (model.RoleId != (int)EnumRoles.Administrator)
            {
                qrcode.UserId = user.Id;
                qrcode.token = Guid.NewGuid();
                _context.QRcodes.Add(qrcode);    
            }
                await _context.SaveChangesAsync();

            return (true, "Registration successful");
        }

        public async Task<(bool Success, string Message)> CreateUser(CreateRequestUserDto model, QRcode qrcode, User user)
        {
            try
            {
                if (_context.Users.Any(x => x.Username == model.Username))
                    return (false, "Username already taken");
                if (_context.Users.Any(x => x.Email == model.Email))
                    return (false, "Email already taken");

                var role = _context.Roles.Single(x => x.Id == user.Role.Id);
                user.Role = role;
                _context.Users.Add(user);
               await _context.SaveChangesAsync();

                if (model.Role != EnumRoles.Administrator)
                {
                    qrcode.UserId = user.Id;
                    qrcode.token = Guid.NewGuid();
                    _context.QRcodes.Add(qrcode);
                    await _context.SaveChangesAsync();
                }

                if ( model.Avatar != null)
                    await PostAvatarUser(user.Id, model.Avatar);

                return (true, "User added");

            } catch(Exception ex)
            {
                return (false, ex.Message);
            }

        }

            public async Task<(bool Success, string Message)> Update (int id, UpdateRequestUserDto model)
        {
            try
            {
                var user = getUser(id);
                if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
                    return (false, "Username '" + model.Username + "' is already taken");
                if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
                    return (false, "Email '" + model.Email + "' is already taken");
                if (user.Role.Name != model.Role && model.Role != null)
                    user.RoleId = (int)model.Role;
                if (model.Avatar != null)
                    await PostAvatarUser(user.Id, model.Avatar);

                    foreach ( var prop in model.GetType().GetProperties())
                {
                    if (prop.Name.ToString() != "Role" && prop.Name.ToString() != "Avatar" && prop.GetValue(model, null) != null)
                    {
                        user.GetType().GetProperty(prop.Name).SetValue(user, prop.GetValue(model, null));
                    }
                }
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return (true, "User updated successfully");

            } catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
        public async Task<(bool Success, string Message, int Count, IEnumerable<User> Items)> UsersListAsync(string token, int? page, int? pageSize, string name, string sortby, bool desc)
        {
            var userId = _jwtUtils.ValidateToken(token);
            try
            {
                var users = _context.Users.Where(usr => usr.Id != userId).Include(usr => usr.Role).Include(usr => usr.QRCode).Include(x => x.UserMetas.Where(x => x.metaLabel == "meta-user-avatar")).AsQueryable();
                if (!String.IsNullOrEmpty(name)){
                     users = users.Where(usr => usr.FirstName.Contains(name) || usr.LastName.Contains(name));
                }
                var count = users.Count();
                switch (sortby)
                {
                    case "firstName":
                        users = users.OrderBy(x => x.FirstName, desc);
                        break;
                    case "roleName":
                        users = users.OrderBy(x => x.Role.Id, desc);
                        break;
                    case "lastName":
                        users = users.OrderBy(x => x.LastName, desc);
                        break ;
                    default:
                        break;
                }
               
                users = users.Paginate(page, pageSize);
                return (true, "Users Finded", count, await users.ToListAsync());
            }
            catch (Exception e)
            {
                return (false, e.Message, 0, new List<User>());
            }

        }
        public async Task<(bool Success, string Message, int Count, IEnumerable<User> Items)> OperatorActionListAsync(int? page, int? pageSize)
        {
            try
            {
                var operators = _context.Users.Include(src => src.Activities.Where(x => x.Entry > System.DateTime.Today)).Include(src => src.QRCode).Where(x => x.Role.Id != (int)EnumRoles.Administrator).AsQueryable();
                var count = operators.Count();
                operators = operators.Paginate(page, pageSize);
                return (true, "Operator info", count, await operators.ToListAsync());

            }
            catch (Exception e)
            {
                return (false, e.Message, 0, new List<User>());

            }

        }

        public async Task<(bool Success, string Message, User user)> GetUserAsync(string token)
        {
            try
            {
                var userId = _jwtUtils.ValidateToken(token);
                var user = await _context.Users.Include(x => x.UserMetas.Where( x => x.metaLabel == "meta-user-avatar")).Where(x => x.Id == userId).Include( x => x.Role).FirstAsync();
                return (true, "Utente trovato", user);

            }
            catch (Exception e)
            {
                return (false, e.Message, new User());
            }

        }

        public async Task<(bool Success, string Message, User user)> GetUserByUsername(string userName)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == userName);
                return (true, "User founded", user);
            }
            catch (Exception e)
            {
                return (false, e.Message, new User());
            }

        }

        public async Task<(bool Success, string Message, string imgBase64)> PostAvatarUser(int? userId, IFormFile file)
        {
            try
            {

                string fileBase64 = "";
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    fileBase64 = Convert.ToBase64String(fileBytes);
                }

                if (_context.UserMetas.Any(x => x.UserId == userId || x.Value == "meta-user-avatar"))
                {
                    var usermeta = _context.UserMetas.Where(x => x.UserId == userId || x.Value == "meta-user-avatar").First();
                    usermeta.Value = fileBase64;
                    _context.UserMetas.Update(usermeta);
                } else
                {
                    var avatar = _context.UserMetas.Add(new UserMeta { UserId = userId, metaLabel = "meta-user-avatar", Value = fileBase64 });

                }

                await _context.SaveChangesAsync();
                return (true, "Avatar Saved", fileBase64);

            }
            catch (Exception e)
            {
                return (false, e.Message,"");
            }
        }
        public async Task<(bool Success, string Message, string imgBase64)> UpdateAvatar(string token, IFormFile file)
        {
            try
            {
                var userId = _jwtUtils.ValidateToken(token);

                var result = await PostAvatarUser(userId, file);

                return (true, "Avatar Saved", result.imgBase64);

            }
            catch (Exception e)
            {
                return (false, e.Message, "");
            }
        }

        public async Task<(bool Success, string Message)> Delete(int id)
        {
            try
            {
                var user = getUser(id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return (true, "user deleted");

            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        public async Task<(bool Success, string Message)> DeleteAvatar(int userId)
        {
            try
            {
                var meta = _context.UserMetas.Single(x => x.UserId == userId && x.metaLabel == "meta-user-avatar");
                _context.UserMetas.Remove(meta);
                await _context.SaveChangesAsync();
                return (true, "avatar deleted");

            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        public async Task<(bool Success, string Message)> DeleteMyAvatar(string token)
        {
            try
            {
                var userId = _jwtUtils.ValidateToken(token);
                var meta = _context.UserMetas.Single(x => x.UserId == userId && x.metaLabel == "meta-user-avatar");
                _context.UserMetas.Remove(meta);
                await _context.SaveChangesAsync();
                return (true, "avatar deleted");

            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

    }

}
