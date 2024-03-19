using System.Threading.Tasks;

namespace api.Interface
{
    public interface IEmailHelper
    {
        Task<bool> SendEmailResetPswd(string email, string name, string jwt);
        Task<bool> SendEmailAddedUser(string username, string email, string name, string jwt);
        Task<bool> SendEmailBlockedUser(string username, string email, string name);
    }
}