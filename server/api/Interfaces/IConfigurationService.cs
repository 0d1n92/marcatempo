using System.Threading.Tasks;
using api.Models.DTOs.Request.Configuration;

namespace api.Interface
{
    public interface IConfigurationService
    {
        public Task<(bool Success, string Message)> UpdateSmtpConfiguration(RequestSmtpConfiguration request);
    }
}
