using Microsoft.AspNetCore.Mvc;
using IdentityApi.Models;
using IdentityApi.Interfaces;
using SharedLibrary.Models;

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

        [HttpGet("CheckToken")]
        public async Task<TDResponse> CheckToken([FromQuery]string token)
        {
            return await _userService.CheckToken(token);
        }


        [HttpPost("SignInRequest")]
        public async Task<TDResponse<long>> SignInRequest([FromBody] UserRequest userRequest)
        {
            return await _userService.SignInRequest(userRequest);
        }        
        
        [HttpPost("ActivateUser")]
        public async Task<TDResponse> ActivateUser([FromBody] ActivationRequest activationRequest)
        {
            return await _userService.ActivateUser(activationRequest.userId, activationRequest.token);
        }

        [HttpPost("ResendToken")]
        public async Task<TDResponse> ResendToken([FromQuery] long userId)
        {
            return await _userService.ResendToken(userId);
        }



        [HttpPost("Login")]
        public async Task<TDResponse<AuthenticateResponse>> Login(AuthenticateRequest model)
        {
            return await _userService.Login(model);
        }
    }
}