using api.Model.Entity;
using api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using api.Models.DTOs.Request.Users;

namespace api.Interface
{
    public interface IUsersService
    {
        Task<(bool Success, string Token, string UserName)> Authenticate(RequestAuthenticateDto model);
        User GetById(int id);
        Task<(bool Success, string Message)> Register(RequestRegisterDto model, QRcode qrcode, User user);
        Task<(bool Success, string Message)> Update(int id, RequestUpdateUserDto model);
        Task<(bool Success, string Message)> Update(string token, RequestUpdateUserDto model);
        Task<(bool Success, string Message, User user)> GetUserAsync(string token);
        Task<(bool Success, string Message)> Delete(int id);
        Task<(bool Success, string Message, int Count, IEnumerable<User> Items)> UsersListAsync(string token, int? page, int? pageSize, string name, string sortby, bool desc);
        Task<(bool Success, string Message, string imgBase64)> PostAvatarUser(int? id, IFormFile file);
        Task<(bool Success, string Message, string imgBase64)> UpdateAvatar(string token, IFormFile file);
        Task<(bool Success, string Message)> CreateUser(RequestCreateUserDto model, QRcode qrcode, User user);
        Task<(bool Success, string Message)> UpdateOperator(User user, RequestUpdateUserDto model);
        Task<(bool Success, string Message)> DeleteAvatar(int userId);
        Task<(bool Success, string Message)> DeleteMyAvatar(string token);
        Task<int> GetUserId(string UserName);
        Task<(bool Success, string Message)> SendRequestPasswordLost(RequestSendRequestDto model);
        Task <(bool Success, string Message)>ResetPasswordUser(string token, ResetPasswordModelDto model);
        Task<(bool Success, string Message)> UpdatePassword(string token, RequestUserUpdatePswdDto model);
    }
}
