
using api.Helpers;
using api.Interface;
using api.Model.Entity;
using api.DTOs;
using System.Collections.Generic;
using System.Linq;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            if (user != null || user != null ? BCryptNet.Verify(model.Password, user.Password): false)
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
            qrcode.token = _jwtUtils.QRGenerateToken(qrcode);
            _context.QRcodes.Add(qrcode);
            await _context.SaveChangesAsync();

            return (true, "Registration successful");
        }

        public async Task<(bool Success, string Message)>Update(int id, UpdateRequestDto model)
        {
            var user = getUser(id);
            if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
               return (false, "Username '" + model.Username + "' is already taken");
            if (!string.IsNullOrEmpty(model.Password))
            {
                user.Password = BCryptNet.HashPassword(model.Password);
            } else
            {
                return (false, "Password is blank");
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            
            return (true, "User updated successfully" );

        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
        }
        private User getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }

}
