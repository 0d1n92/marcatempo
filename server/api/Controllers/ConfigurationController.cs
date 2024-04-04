using api.Authorization;
using api.Interface;
using api.Models.DTOs.Request.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase {

        private readonly IConfigurationService _configurationService;
        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }


        /// <summary>
        ///  update smtp configuration
        /// </summary>
        /// <param name="request" ></param>
 

        [AuthorizeAdmin]
        [HttpPut("ConfigurationSmtp")]

        public async Task<IActionResult> UpdateStmpConfiguration(RequestSmtpConfiguration request)
        {
            var result = await  _configurationService.UpdateSmtpConfiguration(request);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
