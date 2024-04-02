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

        public async Task<(bool Success, string Message)> UpdateStmpConfiguration(RequestStmpConfiguration request)
        {
            var stmpConfig = await _context.Configuration.FirstOrDefaultAsync(conf => conf.Category == "mail");

            if(stmpConfig is not null)
            {
                stmpConfig.Value = JObject.FromObject(request);
                _context.Update(stmpConfig);
                _context.SaveChanges();
                return (true, "stmp configuration update");
            }

            return (false, "update configuration stmp fallied");
            
        }
    }
}
