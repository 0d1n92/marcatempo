using api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using api.Response;
using api.Authorization;
using api.Interface;
using api.Model.Entity;
using System.Threading.Tasks;
using AutoMapper;

namespace api.Controllers
{
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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        ///<summary>
        /// Sign In 
        ///</summary>
        /// <param name="request"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">Unauthorized</response>
        public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateRequest request)
        {
            var user = await  _userService.Authenticate(request);
            var result = _mapper.Map<User, AuthenticateResponse>(user);
            if (user.Username == null) return NotFound();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        ///<summary>s
        /// Register 
        ///</summary>
        /// <param name="request"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">Unauthorized</response>
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var user = _mapper.Map<User>(request);
            var qrcode = _mapper.Map<QRcode>(new QRcode());
            var result = await _userService.Register(request, qrcode, user);
            if(!result.Success) return BadRequest(new { message = result.Message });
            return Ok(new { message = result.Message });
        }

        [AuthorizeAdmin]
        [HttpGet]
        ///<summary>
        /// Get all users
        ///</summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">Unauthorized</response>
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [AuthorizeAdmin]
        [HttpGet("{id}")]
        ///<summary>
        /// Get users
        ///</summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">Unauthorized</response>
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [Authorize]
        [HttpPut("{id}")]
        ///<summary>
        /// Update User 
        ///</summary>
        ///<param name="id"></param>
        /// <param name="request"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">Unauthorized</response>
        public IActionResult Update(int id, UpdateRequest request)
        {
            _userService.Update(id, request);
            return Ok(new { message = "User updated successfully" });
        }

        [Authorize]
        [HttpDelete("{id}")]

        ///<summary>
        /// Delete User
        ///</summary>
        ///<param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">Unauthorized</response>
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
