using api.DTOs;
using System.Threading.Tasks;
using api.Model.Entity;

namespace api.Interface
{
    public interface IQrcodesService
    {
        Task<(bool Sucess, string Message, Model.Entity.Action data)> Postmark(PostmarkerQRcodeRequestDto model, Model.Entity.Action action);
        Task<(bool Success, string Message, QRcode data)> UpdateQrcode(int id);
    }
}
