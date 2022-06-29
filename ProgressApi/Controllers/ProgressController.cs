using Microsoft.AspNetCore.Mvc;
using ProgressApi.Models;
using ProgressApi.Interfaces;
using SharedLibrary.Models;
using Microsoft.AspNetCore.Http.Features;

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
        public async Task<TDResponse> AddProgress(ProgressDto progressDto)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            return await _progressService.AddProgress(progressDto,ip,user);
        }
    }
}