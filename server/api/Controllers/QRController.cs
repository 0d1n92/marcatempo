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
using api.DTOs;
using api.Interface;

namespace api.Controllers;
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
    /// /// <remarks>
    /// QR Operator operator
    /// Entry:
    ///
    ///     POST 
    ///     { 
    ///        "exit": false,
    ///        "userId": 2,
    ///        "qRtoken": "dasdsadasdsadewqrwrfewrewrwerewrewrewrew"  
    ///        
    ///     }   
    /// Exit:
    /// 
    ///     POST 
    ///     { 
    ///        "exit": true,
    ///        "userId": 2,
    ///        "qRtoken": "dasdsadasdsadewqrwrfewrewrwerewrewrewrew"  
    ///        
    ///     }
    /// </remarks>
 
    [AllowAnonymous]
    [HttpPost("postmark")]
    public async Task<IActionResult> FindPostmark(PostmarkerQRcodeRequestDto request)
    {

        var response = await _qrService.Postmark(request);
        var data = _mapper.Map<Model.Entity.Action, PostmarkerQRcodeResponseDto>(response.data);
        return Ok(new { message = response.Message, data = data });
    }

    ///<summary>
    /// Update qrcodes
    ///</summary>
    /// <param name="userID"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    [Authorize]
    [HttpPost("update")]
    public async Task<IActionResult> UpdateQrcode(int userId)
    {
        var data = await _qrService.UpdateQrcode(userId);
        if (!data.Success) return BadRequest(new { Message = data.Message });
        return Ok(data.data);
    }
}

