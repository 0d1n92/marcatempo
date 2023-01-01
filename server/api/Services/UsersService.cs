
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

        public Task<int> GetUserId(string UserName)
        {
            return Task.FromResult(_context.Users.Where(usr => usr.Username == UserName).Select(usr => usr.Id).FirstOrDefault());
        }
        public async Task<(bool Success, string Token, string UserName)> Authenticate(RequestAuthenticateDto model)
        {
            try
            {
                var user = await _context.Users.Include(x => x.Role).SingleOrDefaultAsync(x => x.Username == model.Username);
                if (user != null || user != null ? BCryptNet.Verify(model.Password, user.Password) : false)
                {
                    return (true, _jwtUtils.GenerateToken(user), user.Username);
                }
                 return (false, "User not found", model.Username);
            } catch(Exception ex)
            {
                return (false,ex.Message, "");
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

        public async Task<(bool Success, string Message)> Register(RequestRegisterDto model, QRcode qrcode, User user)
        {

            if (_context.Users.Any(x => x.Username == model.Username))
                return (false, "Username already taken");

            user.Password = BCryptNet.HashPassword(model.Password);
            _context.Users.Add(user);
           

            if (model.RoleId != (int)EnumRoles.Administrator)
            {
                qrcode.UserId = user.Id;
                qrcode.Token = Guid.NewGuid();
                _context.QRcodes.Add(qrcode);    
            }
                await _context.SaveChangesAsync();

            return (true, "Registration successful");
        }

        public async Task<(bool Success, string Message)> CreateUser(RequestCreateUserDto model, QRcode qrcode, User user)
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
                    qrcode.Token = Guid.NewGuid();
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

            public async Task<(bool Success, string Message)> Update (int id, RequestUpdateUserDto model)
        {
            try
            {
                var user = getUser(id);
                if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
                    return (false, "Username already taken");
                if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
                    return (false, "Email already taken");
                if (user.Role.Name != model.Role && model.Role != null)
                    user.RoleId = (int)model.Role;
                if (model.Avatar != null)
                    await PostAvatarUser(user.Id, model.Avatar);
                if (model.deleteAvatar)
                    await DeleteAvatar(user.Id);

                foreach ( var prop in model.GetType().GetProperties())
                {
                    if (prop.Name.ToString() != "deleteAvatar" && prop.Name.ToString() != "Role" && prop.Name.ToString() != "Avatar" && prop.GetValue(model, null) != null)
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
                var users = _context.Users.Where(usr => usr.Id != userId).Include(usr => usr.Role).Include(usr => usr.QRCode).Include(x => x.UserMetas.Where(x => x.Metalabel == "meta-user-avatar")).AsQueryable().ToList();
                if (!String.IsNullOrEmpty(name)){
                    // users = users.Where(usr => usr.FirstName.Contains(name) || usr.LastName.Contains(name)).ToList();
                    var filterdUsr = new List <User>();
                    foreach (var usr in users)
                    { 
                        if ($"{usr.FirstName.ToLower()} {usr.LastName.ToLower()}".Contains(name.ToLower()))
                        {
                            filterdUsr.Add(usr);
                        }
                    }
                    users = filterdUsr;

                }
                var count = users.Count();
                var querableUsr = users.AsQueryable();
                switch (sortby)
                {
                    case "firstName":
                        users = querableUsr.OrderBy(x => x.FirstName, desc).ToList();
                        break;
                    case "roleName":
                        users = querableUsr.OrderBy(x => x.Role.Id, desc).ToList();
                        break;
                    case "lastName":
                        users = querableUsr.OrderBy(x => x.LastName, desc).ToList();
                        break ;
                    default:
                        break;
                }
               
                return (true, "Users Finded", count, users.AsQueryable().Paginate(page, pageSize).ToList());
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
                var user = await _context.Users.Include(x => x.UserMetas.Where( x => x.Metalabel == "meta-user-avatar")).Where(x => x.Id == userId).Include( x => x.Role).FirstAsync();
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
                    fileBase64 = $"data:image/png;base64,{Convert.ToBase64String(fileBytes)}";
                }

                if (_context.UserMetas.Any(x => x.UserId == userId || x.Value == "meta-user-avatar"))
                {
                    var usermeta = _context.UserMetas.Where(x => x.UserId == userId || x.Value == "meta-user-avatar").First();
                    usermeta.Value = fileBase64;
                    _context.UserMetas.Update(usermeta);
                } else
                {
                    var avatar = _context.UserMetas.Add(new UserMeta { UserId = userId, Metalabel = "meta-user-avatar", Value = fileBase64 });

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
                var meta = _context.UserMetas.Single(x => x.UserId == userId && x.Metalabel == "meta-user-avatar");
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
                var meta = _context.UserMetas.Single(x => x.UserId == userId && x.Metalabel == "meta-user-avatar");
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
