using api.DTOs;
using System.Threading.Tasks;
using api.Model.Entity;
using System;

namespace api.Interface
{
    public interface IQrcodesService
    {
        Task<(bool Sucess, string Message, Model.Entity.Action data)> Postmark(PostmarkerQRcodeRequestDto model);
        Task<(bool Success, string Message, QRcode data)> UpdateQrcode(Guid token);
    }
}
