using System.Threading.Tasks;

namespace api.Interface
{
    public interface IEmailHelper
    {
        Task<bool> SendEmailResetPswd(string email, string name, string jwt);
    }
}