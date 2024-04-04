using api.Helpers;
using api.Interface;
using api.Models.DTOs.Request.Configuration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly DataContext _context;
        public ConfigurationService(DataContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message)> UpdateSmtpConfiguration(RequestSmtpConfiguration request)
        {
            var smtpConfig = await _context.Configuration.FirstOrDefaultAsync(conf => conf.Category == "mail");

            if(smtpConfig is not null)
            {
                smtpConfig.Value = JObject.FromObject(request);
                _context.Update(smtpConfig);
                _context.SaveChanges();
                return (true, "smtp configuration update");
            }

            return (false, "update configuration stmp fallied");
            
        }
    }
}
