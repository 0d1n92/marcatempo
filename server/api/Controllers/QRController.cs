using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using api.Authorization;
using api.Helpers;
using AutoMapper;
using Microsoft.Extensions.Options;
using api.DTOs;
using api.Interface;

namespace api.Controllers;
[Authorize]
[ApiController]
[Route("qrcodes")]
public class QRController : ControllerBase
{
    private IQrcodesService _qrService;
    private IMapper _mapper;
    public QRController(
        IQrcodesService qrService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _qrService = qrService;
        _mapper = mapper;
    }

    ///<summary>
    /// Timbratura
    ///</summary>
    /// <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// /// <remarks>
    /// QR Operator operator
    /// Entry:
    ///
    ///     POST
    ///     {
    ///        "exit": false,
    ///
    ///        "token": "81a130d2-502f-4cf1-a376-63edeb000e9f"
    ///
    ///     }
    /// Exit:
    ///
    ///     POST
    ///     {
    ///        "exit": true,
    ///
    ///         "token": "81a130d2-502f-4cf1-a376-63edeb000e9f"
    ///
    ///     }
    /// </remarks>

    [AllowAnonymous]
    [HttpPost("postmark")]
    public async Task<ActionResult> FindPostmark(PostmarkerQRcodeRequestDto request)
    {
        var response = await _qrService.Postmark(request);
        if (!response.Success) return BadRequest(new { Message = response.Message });
         var data = _mapper.Map<Model.Entity.Action, PostmarkerQRcodeResponseDto>(response.data);
        return Ok(new { message = response.Message, data = data });
    }

    ///<summary>
    /// Update qrcodes
    ///</summary>
    /// <param name="qrcode"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    [Authorize]
    [HttpPost("update")]
    public async Task<ActionResult> UpdateQrcode( QrcCodeDtoRequest qrcode )
    {
        var data = await _qrService.UpdateQrcode(new Guid(qrcode.token));
        if (!data.Success) return BadRequest(new { Message = data.Message });
        return Ok(data.data);
    }
}

