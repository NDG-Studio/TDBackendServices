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

        /// <summary>
        /// [LoginRequired]
        /// Get spesific user via id
        /// </summary>
        /// <param name="Data">UserId</param>
        /// <returns></returns>
        [LoginRequired]
        [HttpPost("GetUserById")]
        public async Task<TDResponse<UserDto>> GetUserById([FromBody] BaseRequest<long> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _userService.GetUserById(req);
        }

        [HttpPost("CheckToken")]
        public async Task<TDResponse> CheckToken([FromBody] BaseRequest<string> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _userService.CheckToken(req);
        }


        [HttpPost("SignInRequest")]
        public async Task<TDResponse<long>> SignInRequest([FromBody] BaseRequest<UserRequest> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _userService.SignInRequest(req);
        }        
        
        [HttpPost("ActivateUser")]
        public async Task<TDResponse> ActivateUser([FromBody] BaseRequest<ActivationRequest> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _userService.ActivateUser(req);
        }

        [HttpPost("ResendToken")]
        public async Task<TDResponse> ResendToken([FromBody] BaseRequest<long> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _userService.ResendToken(req);
        }

        [HttpPost("Login")]
        public async Task<TDResponse<AuthenticateResponse>> Login([FromBody] BaseRequest<AuthenticateRequest> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _userService.Login(req);
        }
    }
}