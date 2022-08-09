using api.Model.Entity;
using api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace api.Interface
{
    public interface IUsersService
    {
        Task<(bool Success, string Token)> Authenticate(AuthenticateRequestDto model);
        User GetById(int id);
        Task<(bool Success, string Message)> Register(RegisterRequestDto model, QRcode qrcode, User user);
        Task<(bool Success, string Message, int Count, IEnumerable<User> Items)> OperatorActionListAsync(int? page, int? pageSize);
        Task<(bool Success, string Message)> Update(int id, UpdateRequestUserDto model);
        Task<(bool Success, string Message, User user)> GetUserAsync(string token);
        Task<(bool Success, string Message)> Delete(int id);
        Task<(bool Success, string Message, int Count, IEnumerable<User> Items)> UsersListAsync(string token, int? page, int? pageSize, string name, string sortby, bool desc);
        Task<(bool Success, string Message, string imgBase64)> PostAvatarUser(int? id, IFormFile file);
        Task<(bool Success, string Message, string imgBase64)> UpdateAvatar(string token, IFormFile file);
        Task<(bool Success, string Message)> CreateUser(CreateRequestUserDto model, QRcode qrcode, User user);
    }
}
