using api.DTOs;
using System.Threading.Tasks;
using api.Model.Entity;

namespace api.Interface
{
    public interface IQrcodesService
    {
        PostmarkerQRcodeResponseDto Postmark(PostmarkerQRcodeRequestDto model);
        Task<(bool Success, string Message, QRcode qrcode)> UpdateQrcode(int id);
    }
}
