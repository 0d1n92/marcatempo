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
        ///  update stmp configuration
        /// </summary>
        /// <param name="request" ></param>
 

        [AuthorizeAdmin]
        [HttpPut("ConfigurationStmp")]

        public async Task<IActionResult> UpdateStmpConfiguration(RequestStmpConfiguration request)
        {
            var result = await  _configurationService.UpdateStmpConfiguration(request);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
