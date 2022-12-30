using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api.Authorization;
using api.Helpers;
using AutoMapper;
using Microsoft.Extensions.Options;
using api.DTOs;
using api.Interface;
using System.Collections.Generic;
using System;

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
    [AuthorizeAdmin]
    [HttpPost("actionoperators")]
    public async Task<ActionResult<PaginatedList<List<ResponseListofActionUsersDto>>>> OperatorActionListAsync(int? page, int? pageSize, RequestActionListDto request)
    {
        var result = await _actService.OperatorActionListAsync(page, pageSize, request);
        if (!result.Success) return BadRequest(new { message = result.Message });
        return Ok(new PaginatedList<ResponseListofActionUsersDto>(result.Count, _mapper.Map<List<ResponseListofActionUsersDto>>(result.Items))) ;
    }
    ///<summary>
    /// Delete Action
    ///</summary>
    ///  <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    /// 
    [AuthorizeAdmin]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _actService.Delete(id);
        if (!response.Success) return BadRequest(new { Message = response.Message });
        return Ok(new { message = "Action deleted successfully" });
    }

    ///<summary>
    /// Update Action
    ///</summary>
    /// <param name="id"></param>
    ///  <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    /// 
    [AuthorizeAdmin]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] RequestActionDto request)
    {
        var response = await _actService.Update(id,request);
        if (!response.Success) return BadRequest(new { Message = response.Message });
        return Ok(new { message = "Action update successfully" });
    }

    ///<summary>
    /// Calcolate totals
    ///</summary>
    ///  <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    /// 
    [AuthorizeAdmin]
    [HttpPost("total")]
    public  IActionResult CalcolateTotal(RequestActionTotalDto request)
    {
        var response =  _actService.CalcolateTotal(request);
        if (!response.Success) return BadRequest(new { Message = response.Totals });
        return Ok(new { Totals = response.Totals });
    }


    ///<summary>
    /// Dowload csv
    ///</summary>
    ///  <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    /// 
    [AuthorizeAdmin]
    [HttpPost("export")]
    public IActionResult ExportCsvFile(List<RequestActionCsvDto> request)
    {
        var response = _actService.ExportCsvFile(request);
        if (!response.Success) return BadRequest(new { Message = "Impossible to export csv"});
       
        return File(response.stream, "application/octet-stream", $"postmark-{DateTime.Now.ToFileTime()}.csv");
    }

}

