
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
        public async Task<(bool Success, string Message, List<User> users)> UsersListAsync(string token)
        {
            var userId = _jwtUtils.ValidateToken(token);
            try
            {
                var users = await _context.Users.Where(usr => usr.Id != userId).Include( usr => usr.Role).Include(usr => usr.QRCode).ToListAsync();
                return (true, "Users Finded", users);
            } catch (Exception e)
            {
                return (false, e.Message,new List<User>()); 
            }

        }
        public async Task<(bool Success, string Message, List<User> operators)> OperatorActionListAsync()
        {
            try
            {
                var operators = await _context.Users.Include(src => src.Activities.Where(x => x.Entry > System.DateTime.Today)).Include(src => src.QRCode).Where(x => x.Role.Id != (int)EnumRoles.Administrator).ToListAsync();
                return (true, "Operator info", operators);

            }
            catch (Exception e)
            {
                return (false, e.Message, new List<User>());

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
                var user = await _context.Users.Include(x => x.Role).Where(x => x.Id == userId).FirstAsync();
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
            } catch (Exception e)
            {
                return(false, e.Message, new User());
            }

        }
    }

}
