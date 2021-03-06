
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

        public async Task<User> Authenticate(AuthenticateRequestDto model)
        {
            var user = await _context.Users.Include(x => x.Role).SingleOrDefaultAsync(x => x.Username == model.Username);
            if (user != null || user != null ? BCryptNet.Verify(model.Password, user.Password) : false)
            {
                user.Token = _jwtUtils.GenerateToken(user);
                return user;
            }

            return new User();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        private User getUser(int id)
        {
            var user = _context.Users.Find(id);
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
                return (false, "Username already Taken");

            user.Password = BCryptNet.HashPassword(model.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            qrcode.UserId = user.Id;

            if (model.RoleId != (int)EnumRoles.Administrator)
            {
                qrcode.token = Guid.NewGuid();
                _context.QRcodes.Add(qrcode);
                await _context.SaveChangesAsync();
            }

            return (true, "Registration successful");
        }

        public async Task<(bool Success, string Message)> Update(int id, UpdateRequestDto model)
        {
            var user = getUser(id);
            if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
                return (false, "Username '" + model.Username + "' is already taken");
            if (!string.IsNullOrEmpty(model.Password))
            {
                user.Password = BCryptNet.HashPassword(model.Password);
            }
            else
            {
                return (false, "Password is blank");
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return (true, "User updated successfully");

        }
        public async Task<(bool Success, string Message, int Count, IEnumerable<User> Items)> UsersListAsync(string token, int? page, int? pageSize)
        {
            var userId = _jwtUtils.ValidateToken(token);
            try
            {
                var users = _context.Users.Where(usr => usr.Id != userId).Include(usr => usr.Role).Include(usr => usr.QRCode).Include(x => x.UserMetas.Where(x => x.metaLabel == "meta-user-avatar")).AsQueryable();
                var count = users.Count();
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

    }

}
