using Microsoft.AspNetCore.Mvc;
using PlayerBaseApi.Interfaces;
using PlayerBaseApi.Models;
using SharedLibrary.Models;

namespace PlayerBaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroController : ControllerBase
    {

        private readonly ILogger<HeroController> _logger;
        private readonly IHeroService _heroService;

        public HeroController(ILogger<HeroController> logger, IHeroService heroService)
        {
            _logger = logger;
            _heroService = heroService;
        }

        [LoginRequired]
        [HttpPost("GetHeroTypes")]
        public async Task<TDResponse<List<HeroDTO>>> GetHeroTypes([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.GetHeroTypes(req, user);
        }
    }
}