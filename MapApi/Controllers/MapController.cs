using MapApi.Interfaces;
using MapApi.Models;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace MapApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : ControllerBase
    {

        private readonly ILogger<MapController> _logger;
        private readonly IMapService _mapService;

        public MapController(ILogger<MapController> logger, IMapService mapService)
        {
            _logger = logger;
            _mapService = mapService;
        }


        [LoginRequired]
        [HttpPost("GetMapItemTypes")]
        public async Task<TDResponse<List<MapItemTypeDTO>>> GetMapItemTypes([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _mapService.GetMapItemTypes(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("AddUserBase")]
        public async Task<TDResponse<MapItemDTO>> AddUserBase([FromBody] BaseRequest<bool> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _mapService.AddUserBase(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("MoveUserBase")]
        public async Task<TDResponse> MoveUserBase([FromBody] BaseRequest<MapItemDTO> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _mapService.MoveUserBase(req, user);
        }

        [LoginRequired]
        [HttpPost("GetMapByAreaIds")]
        public async Task<TDResponse<List<MapInfoDto>>> GetMapByAreaIds([FromBody] BaseRequest<List<int>> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _mapService.GetMapByAreaIds(req, user);
        }
       

    }
}