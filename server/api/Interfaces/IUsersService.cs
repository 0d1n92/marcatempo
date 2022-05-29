using api.Model.Entity;
using api.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interface
{
    public interface IUsersService
    {
        Task<User> Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        Task<(bool Success, string Message)> Register(RegisterRequest model, QRcode qrcode, User user);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
