using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using api.Authorization;
using api.Helpers;
using AutoMapper;
using Microsoft.Extensions.Options;
using api.DTOs;
using api.Interface;
using System.Collections.Generic;

namespace api.Controllers;
[Authorize]
[ApiController]
[Route("action")]
public class ActionsController : ControllerBase
{
    private IActionsService _actService;
    private IMapper _mapper;
    public ActionsController(
        IActionsService actService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _actService = actService;
        _mapper = mapper;
    }
    ///<summary>
    /// Get List of Action 
    ///</summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    ///  <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    /// 
    [AllowAnonymous]
    [HttpPost("actionoperators")]
    public async Task<ActionResult<UserActions>> OperatorActionListAsync(int? page, int? pageSize, RequestActionListDto request)
    {
        var result = await _actService.OperatorActionListAsync(page, pageSize, request);

        if (!result.Success) return BadRequest(new { message = result.Message });
        return Ok(result.Items);
    }


}

