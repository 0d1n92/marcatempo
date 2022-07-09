using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Authorization;
using api.Services;
using api.Helpers;
using AutoMapper;
using Microsoft.Extensions.Options;
using api.Response;
using api.Interface;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("qrcodes")]
    public class QRController : ControllerBase
    {
        private readonly DataContext _context;
        private IQrcodesService _qrService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public QRController(
            DataContext context,
            IQrcodesService qrService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;

            _qrService = qrService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        ///<summary>
        /// Timbratura
        ///</summary>
        /// <param name="request"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">Unauthorized</response>
        [AllowAnonymous]
        [HttpPost("postmark")]
        public IActionResult FindPostmark(PostmarkerQRcodeRequestDto request)
        {
            var response = _qrService.Postmarker(request);
            return Ok(response);
        }
    }
}
