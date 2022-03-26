using api.Authorization;
using api.Helpers;
using api.Interface;
using api.Response;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using BCryptNet = BCrypt.Net.BCrypt;

namespace api.Services
{
    public class UsersService : IUsersService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UsersService(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);
            if (user == null || !BCryptNet.Verify(model.Password, user.Password))
                throw new AppException("Username or password is incorrect");
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = "try_token";
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Register(RegisterRequest model)
        {

            if (_context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");
            var user = _mapper.Map<User>(model);
            var qrcode = _mapper.Map<QRcode>(new QRcode());
            user.Password = BCryptNet.HashPassword(model.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            qrcode.UserId = user.Id;
            qrcode.token = _jwtUtils.QRGenerateToken(qrcode);
            _context.QRcodes.Add(qrcode);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = getUser(id);
            if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");
            if (!string.IsNullOrEmpty(model.Password))
                user.Password = BCryptNet.HashPassword(model.Password);
            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
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
