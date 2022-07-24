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
        Task<(bool Success, string Message, int Count, IEnumerable<User> Items)> OperatorActionListAsync(int? page, int? pageSize);
        Task<(bool Success, string Message)> Update (int id, UpdateRequestDto model);
        Task<(bool Success, string Message, User user)> GetUserAsync(string token);
        Task<(bool Success, string Message)> Delete(int id);
        Task<(bool Success, string Message, int Count, IEnumerable<User> Items)> UsersListAsync(string token, int? page, int? pageSize);
    }
}
