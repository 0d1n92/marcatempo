using api.DTOs;
using System.Threading.Tasks;
using api.Model.Entity;
using System;

namespace api.Interface
{
    public interface IQrcodesService
    {
        Task<(bool Success, string Message, Model.Entity.Action data)> Postmark(RequestPostmarkerQRcodeDto model);
        Task<(bool Success, string Message, string data)> UpdateQrcode(Guid token);
    }
}
