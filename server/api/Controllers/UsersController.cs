
using Microsoft.AspNetCore.Mvc;
using api.DTOs;
using api.Authorization;
using api.Interface;
using api.Model.Entity;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using api.Helpers;
using Microsoft.AspNetCore.Http;


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
    public async Task<ActionResult> Authenticate(RequestAuthenticateDto request)
    {
        var result = await _userService.Authenticate(request);

        if (!result.Success) return NotFound(new { Message = result.Token });
        return Ok(new { token = result.Token, userName= result.UserName });
    }

    ///<summary>
    /// Get List of users
    ///</summary>
    /// <param name="page"></param> 
    /// <param name="pageSize"></param>
    /// <param name="name"></param> 
    /// <param name="sortby"></param> 
    /// <param name="desc"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpGet("users-list")]
    public async Task<ActionResult<PaginatedList<ResponsUsersDto>>> UsersListAsync(int? page, int? pageSize, string name, string sortby, bool desc)
    {
        var token = Request.Headers["Authorization"];
        var result = await _userService.UsersListAsync(token, page, pageSize, name, sortby, desc);

        if (!result.Success) return BadRequest(new { message = result.Message });
        return Ok(new PaginatedList<ResponsUsersDto>(result.Count, _mapper.Map<List<ResponsUsersDto>>(result.Items)));

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
        if (!response.Success) return BadRequest(new { Mesage = response.Message });
        var user = _mapper.Map<User, ResponseAuthenticateDto>(response.user);
        return Ok(new { user = user });
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
    public async Task<ActionResult> Register(RequestRegisterDto request)
    {
        var user = _mapper.Map<User>(request);
        var qrcode = _mapper.Map<QRcode>(new QRcode());
        var result = await _userService.Register(request, qrcode, user);
        if (!result.Success) return BadRequest(new { message = result.Message });
        return Ok(new { message = result.Message });
    }
    ///<summary>
    /// Create
    ///</summary>
    /// <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    [AuthorizeAdmin]
    [HttpPost("create")]
    public async Task<ActionResult> Create([FromForm] RequestCreateUserDto request)
    {
        var user = _mapper.Map<User>(request);
        var qrcode = _mapper.Map<QRcode>(new QRcode());
        var result = await _userService.CreateUser(request, qrcode, user);
        if (!result.Success) return BadRequest(new { message = result.Message });
        return Ok(new { message = result.Message });
    }
    ///<summary>
    /// Save Avatar users
    ///</summary>
    /// <param name="userId"></param> 
    /// <param name="file"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpPost("save-avatar/{userId}")]

    public async Task<IActionResult> PostAvatarUser(int userId, IFormFile file)
    {

        var response = await _userService.PostAvatarUser(userId, file);
        if (!response.Success) return BadRequest(new { Mesage = response.Message });
        return Ok(new { image = response.imgBase64 });
    }

    ///<summary>
    /// Save my avatar
    ///</summary>
    /// <param name="file"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [Authorize]
    [HttpPost("save-avatar")]

    public async Task<IActionResult> UpdateAvatarUser(IFormFile file)
    {
        var token = Request.Headers["Authorization"];
        var response = await _userService.UpdateAvatar(token, file);
        if (!response.Success) return BadRequest(new { Mesage = response.Message });
        return Ok(new { image = response.imgBase64 });
    }


    ///<summary>
    /// Update user 
    ///</summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromForm] RequestUpdateUserDto request, int id)
    {
        
        var result = await _userService.Update(id,request);
        if (!result.Success) return BadRequest(new { message = result.Message });
        return Ok(new { message = result.Message });
    }
    ///<summary>
    /// Update my profile
    ///</summary>
    /// <param name="request"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>

    [AuthorizeAdmin]
    [HttpPut("profile")]
    public async Task<IActionResult> UpdateMyProfile([FromForm] RequestUpdateUserDto request)
    {
        var token = Request.Headers["Authorization"];
        var result = await _userService.Update(token, request);
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
    /// Delete avatar by user id
    ///</summary>
    ///<param name="userId"></param>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    [AuthorizeAdmin]
    [HttpDelete("avatar/{userId}")]
    public async Task<IActionResult> DeleteAvatar(int userId)
    {
        var response = await _userService.Delete(userId);
        if (!response.Success) return BadRequest(new { Message = response.Message });
        return Ok(new { message = "Avatar deleted successfully" });
    }

    ///<summary>
    /// Delete avatar by token
    ///</summary>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response> 
    /// <response code="401">Unauthorized</response>
    [Authorize]
    [HttpDelete("avatar")]
    public async Task<IActionResult> DeleteMyAvatar()
    {
        var token = Request.Headers["Authorization"];
        var response = await _userService.DeleteMyAvatar(token);
        if (!response.Success) return BadRequest(new { Message = response.Message });
        return Ok(new { message = "Avatar deleted successfully" });
    }

}
