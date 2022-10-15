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
        public async Task<TDResponse<UserTDInfoDTO>> GetNextWave(BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user!.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _progressService.GetNextWave(req, user);
        }

        //[HttpPost("GetZombies")]
        //public async Task<TDResponse<List<EnemyDTO>>> GetZombies([FromBody] BaseRequest req)
        //{
        //    var user = (HttpContext.Items["User"] as UserDto);
        //    req.SetUser(user?.Id);
        //    req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        //    return await _progressService.GetZombies(req);
        //}

        //[HttpPost("GetTowers")]
        //public async Task<TDResponse<List<TowerDTO>>> GetTowers([FromBody] BaseRequest req)
        //{
        //    var user = (HttpContext.Items["User"] as UserDto);
        //    req.SetUser(user?.Id);
        //    req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        //    return await _progressService.GetTowers(req);
        //}        

        //[HttpPost("GetStages")]
        //public async Task<TDResponse<List<StageDTO>>> GetStages([FromBody] BaseRequest req)
        //{
        //    var user = (HttpContext.Items["User"] as UserDto);
        //    req.SetUser(user?.Id);
        //    req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        //    return await _progressService.GetStages(req);
        //}

        //[LoginRequired]
        //[HttpPost("GetUserStageStatus")]
        //public async Task<TDResponse<List<StageStatusDTO>>> GetUserStageStatus(BaseRequest req)
        //{
        //    var user = (HttpContext.Items["User"] as UserDto);
        //    req.SetUser(user?.Id);
        //    req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
        //    return await _progressService.GetUserStageStatus(req, user);
        //}        


    }
}