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
       

    }
}