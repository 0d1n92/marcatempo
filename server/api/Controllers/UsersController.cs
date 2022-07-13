
using Microsoft.AspNetCore.Mvc;
using api.DTOs;
using api.Authorization;
using api.Interface;
using api.Model.Entity;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace api.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    private readonly IUsersService _userService;
    private readonly IMapper _mapper;

    public UsersController(
        IUsersService userService,
         IMapper mapper
        )
    {

        _userService = userService;
        _mapper = mapper;

    }

    ///<summary>
    /// Sign In 
    ///</summary>
    /// <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    /// /// <remarks>
    /// User administrator:
    ///
    ///     POST 
    ///     {
    ///        "username": "administrator",
    ///        "password": "qwerty"
    ///        
    ///     }
    /// User Operator:
    ///
    ///     POST 
    ///     {
    ///        "username": "operator",
    ///        "password": "qwerty"
    ///        
    ///     }
    ///
    /// </remarks>
    /// 
    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<ActionResult<AuthenticateResponseDto>> Authenticate(AuthenticateRequestDto request)
    {
        var user = await _userService.Authenticate(request);
        var result = _mapper.Map<User, AuthenticateResponseDto>(user);
        if (user.Username == null) return NotFound();
        return Ok(result);
    }


    ///<summary>
    /// Register 
    ///</summary>
    /// <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    [AuthorizeAdmin]
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterRequestDto request)
    {
        var user = _mapper.Map<User>(request);
        var qrcode = _mapper.Map<QRcode>(new QRcode());
        var result = await _userService.Register(request, qrcode, user);
        if (!result.Success) return BadRequest(new { message = result.Message });
        return Ok(new { message = result.Message });
    }


    ///<summary>
    /// Get all users
    ///</summary>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    ///<summary>
    /// Get user
    ///</summary>
    /// <param name="id"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }


    ///<summary>
    /// Update user 
    ///</summary>
    ///<param name="id"></param>
    /// <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequestDto request)
    {
        var result = await _userService.Update(id, request);
        if (!result.Success) return BadRequest(new { message = result.Message });
        return Ok(new { message = result.Message });
    }

    ///<summary>
    /// Delete user
    ///</summary>
    ///<param name="id"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
       var response = await _userService.Delete(id);
        if (!response.Success) return BadRequest(new { Message = response.Message });
        return Ok(new { message = "User deleted successfully" });
    }

    ///<summary>
    /// Get List of Action Operator
    ///</summary>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpGet("actionoperators")]
    public async Task<IActionResult> OperatorListActionAsync()
    {
        var result = await _userService.OperatorActionListAsync();
        
        if(!result.Success) return BadRequest(new { message = result.Message});
        return Ok(new {data = _mapper.Map<IList<User>, IList<ResponseListofActionUsersDto>>(result.usersAction) });

    }

    ///<summary>
    /// Get List of Operators
    ///</summary>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpGet("operators")]
    public async Task<IActionResult> OperatorListAsync()
    {
        var result = await _userService.OperatorActionListAsync();

        if (!result.Success) return BadRequest(new { message = result.Message });
        return Ok(new { data = _mapper.Map<IList<User>>(result.usersAction) });

    }
    ///<summary>
    /// Get User info by token
    ///</summary>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [Authorize]
    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserAsync()
    {
        var token = Request.Headers["Authorization"];
        var response = await _userService.GetUserAsync(token);
        if (!response.Success) return BadRequest(new { Mesage = response.Message});
        var user = _mapper.Map<User, AuthenticateResponseDto>(response.data);
        return Ok(new {data = user});
    }
}
