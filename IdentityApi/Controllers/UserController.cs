using Microsoft.AspNetCore.Mvc;
using IdentityApi.Models;
using IdentityApi.Helpers;
using IdentityApi.Interfaces;

namespace IdentityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {


        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [LoginRequired]
        [HttpGet("GetUserById/{id}")]
        public async Task<TDResponse<UserDto>> GetUserById(long id)
        {
            return await _userService.GetUserById(id);
        }
        

        // [AdminRequired]
        [HttpPost("AddUser")]
        public async Task<TDResponse> AddUser([FromBody] UserRequest userRequest)
        {
            return await _userService.AddUser(userRequest);
        }
        


        [HttpPost("Login")]
        public async Task<TDResponse<AuthenticateResponse>> Login(AuthenticateRequest model)
        {
            return await _userService.Login(model);
        }
    }
}