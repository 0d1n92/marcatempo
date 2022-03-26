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


        [AllowAnonymous]
        [HttpPost("postmark")]
        public IActionResult FindPostmark(PostmarkerQRcodeRequest model)
        {
            var response = _qrService.Postmarker(model);
            return Ok(response);
        }
    }
}
