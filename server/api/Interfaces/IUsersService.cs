using api.Model.Entity;
using api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interface
{
    public interface IUsersService
    {
        Task<User> Authenticate(AuthenticateRequestDto model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        Task<(bool Success, string Message)> Register(RegisterRequestDto model, QRcode qrcode, User user);
        Task<(bool Success, string Message, List<User> data)> OperatorListAsync();
        Task<(bool Success, string Message)> Update (int id, UpdateRequestDto model);
        Task<(bool Success, string Message, User data)> GetUserAsync(string token);
        void Delete(int id);
    }
}
