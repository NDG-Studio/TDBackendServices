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
        public async Task<TDResponse> AddProgress([FromBody] BaseRequest<ProgressDto> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _progressService.AddProgress(req, user);
        }
    }
}