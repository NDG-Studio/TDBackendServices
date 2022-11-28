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
        
        [LoginRequired]
        [HttpPost("GetMapByBoundBox")]
        public async Task<TDResponse<List<InfoWithAreaDTO>>> GetMapByBoundBox([FromBody] BaseRequest<BoundBox> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _mapService.GetMapByBoundBox(req, user);
        }


        [LoginRequired]
        [HttpPost("GetMapByBoundBoxV2")]
        public async Task<TDResponse<List<MapInfoDto>>> GetMapByBoundBoxV2([FromBody] BaseRequest<BoundBox> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _mapService.GetMapByBoundBoxV2(req, user);
        }



        [LoginRequired]
        [HttpPost("GetApeIsRecommended")]
        public async Task<TDResponse<bool>> GetApeIsRecommended([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _mapService.GetApeIsRecommended(req, user);
        }


        [LoginRequired]
        [HttpPost("GetAllGates")]
        public async Task<TDResponse<List<MapItemDTO>>> GetAllGates([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _mapService.GetAllGates(req, user);
        }



       

    }
}