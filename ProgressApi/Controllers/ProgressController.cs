using Microsoft.AspNetCore.Mvc;
using ProgressApi.Models;
using ProgressApi.Interfaces;
using SharedLibrary.Models;

namespace ProgressApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {


        private readonly ILogger<ProgressController> _logger;
        private readonly IProgressService _progressService;

        public ProgressController(ILogger<ProgressController> logger, IProgressService progressService)
        {
            _logger = logger;
            _progressService = progressService;
        }

        [LoginRequired]
        [HttpPost("AddProgress")]
        public async Task<TDResponse> AddProgress([FromBody] BaseRequest<ProgressDTO> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user!.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _progressService.AddProgress(req, user);
        }

        [LoginRequired]
        [HttpPost("GetNextWave")]
        public async Task<TDResponse<UserTDInfoDTO>> GetNextWave([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user!.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _progressService.GetNextWave(req, user);
        }


        [LoginRequired]
        [HttpPost("ResetLevel")]
        public async Task<TDResponse> ResetLevel([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user!.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _progressService.ResetLevel(req, user);
        }

        [LoginRequired]
        [HttpPost("GetTutorialWave")]
        public async Task<TDResponse<UserTDInfoDTO>> GetTutorialWave([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user!.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _progressService.GetTutorialWave(req,user);
        }

        [LoginRequired]
        [HttpPost("AddTutorialProgress")]
        public async Task<TDResponse> AddTutorialProgress([FromBody] BaseRequest<ProgressDTO> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user!.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _progressService.AddTutorialProgress(req,user);
        }

    }
}