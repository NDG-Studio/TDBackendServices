using Microsoft.AspNetCore.Mvc;
using PlayerBaseApi.Interfaces;
using PlayerBaseApi.Models;
using SharedLibrary.Models;

namespace PlayerBaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerBaseController : ControllerBase
    {

        private readonly ILogger<PlayerBaseController> _logger;
        private readonly IPlayerBaseService _playerBaseService;

        public PlayerBaseController(ILogger<PlayerBaseController> logger, IPlayerBaseService playerBaseService)
        {
            _logger = logger;
            _playerBaseService = playerBaseService;
        }

        [LoginRequired]
        [HttpPost("GetBuildings")]
        public async Task<TDResponse<List<PlayerBasePlacementDTO>>> GetBuildings([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetBuildings(req, user);
        }

        [LoginRequired]
        [HttpPost("GetBuildingTypes")]
        public async Task<TDResponse<List<BuildingTypeDTO>>> GetBuildingTypes([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetBuildingTypes(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("AddPlayerBaseBuilding")]
        public async Task<TDResponse> AddPlayerBaseBuilding([FromBody] BaseRequest<PlayerBaseBuildingRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.AddPlayerBaseBuilding(req, user);
        }
    }
}