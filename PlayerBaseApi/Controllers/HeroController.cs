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

        [LoginRequired]
        [HttpPost("GetPlayerHeroes")]
        public async Task<TDResponse<List<PlayerHeroDTO>>> GetPlayerHeroes([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.GetPlayerHeroes(req, user);
        }

        [LoginRequired]
        [HttpPost("GetHeroesThresholds")]
        public async Task<TDResponse<List<HeroLevelThresholdDTO>>> GetHeroesThresholds([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.GetHeroesThresholds(req, user);
        }

        [LoginRequired]
        [HttpPost("AddHeroExperience")]
        public async Task<TDResponse<bool>> AddHeroExperience([FromBody] BaseRequest<AddHeroExperienceRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.AddHeroExperience(req, user);
        }

        [LoginRequired]
        [HttpPost("GetHeroTalentTreeByHeroId")]
        public async Task<TDResponse<List<TalentTreeDTO>>> GetHeroTalentTreeByHeroId([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.GetHeroTalentTreeByHeroId(req, user);
        }
    }
}