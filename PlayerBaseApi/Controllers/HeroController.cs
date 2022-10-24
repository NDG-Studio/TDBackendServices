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
        [HttpPost("GetPlayersHeroById")]
        public async Task<TDResponse<PlayerHeroDTO>> GetPlayersHeroById([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.GetPlayersHeroById(req, user);
        }

        /// <summary>
        /// AddHeroExperience SADECE TEST ICIN KULLANILMALIDIR !!! HeroXp kullanma islemi icin 'UseHeroExp' i kullaniniz
        /// </summary>
        [LoginRequired]
        [HttpPost("AddHeroExperience")]
        public async Task<TDResponse<bool>> AddHeroExperience([FromBody] BaseRequest<AddHeroExperienceRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.AddHeroExperience(req, user);
        }

        /// <summary>
        /// Oyuncu envanterinde bulunan heroxp pack itemlari kullanilarak heroya xp verir, itemleri almak icin bknz: GetPlayersHeroXpItems
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// UseHeroExperienceRequest.HeroId = xp eklenecek heroid
        /// <br/>
        /// UseHeroExperienceRequest.ItemId = xp eklemek icin kullanilacak itemin idsi
        /// <br/>
        /// UseHeroExperienceRequest.Count = kullanilacak itemin sayisi
        /// <br/>
        /// Input: BaseRequest &lt; UseHeroExperienceRequest &gt;
        /// <br/>
        /// Output: TDResponse &lt; bool &gt;       Not: Hero level atlamissa true doner
        /// </remarks>
        [LoginRequired]
        [HttpPost("UseHeroExp")]
        public async Task<TDResponse<bool>> UseHeroExp([FromBody] BaseRequest<UseHeroExperienceRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.UseHeroExp(req, user);
        }

        /// <summary>
        /// Oyuncu envanterinde bulunan heroxp pack itemlarini getirir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse&lt; List &lt; PlayerItemDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetPlayersHeroXpItems")]
        public async Task<TDResponse<List<PlayerItemDTO>>> GetPlayersHeroXpItems([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.GetPlayersHeroXpItems(req, user);
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
        
        [LoginRequired]
        [HttpPost("AddHeroTalentNodeByNodeId")]
        public async Task<TDResponse> AddHeroTalentNodeByNodeId([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.AddHeroTalentNodeByNodeId(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("GetHeroSkillsByHeroId")]
        public async Task<TDResponse<List<HeroSkillDTO>>> GetHeroSkillsByHeroId([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.GetHeroSkillsByHeroId(req, user);
        }
        
        [LoginRequired]
        [HttpPost("UpgradeHeroSkillBySkillId")]
        public async Task<TDResponse> UpgradeHeroSkillBySkillId([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.UpgradeHeroSkillBySkillId(req, user);
        }


        /// <summary>
        /// Oyuncu sahip oldugu herocardlar ile kendisinde olmayan bir heroya sahip olur
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// BaseRequest.Data = alinacak heroid
        /// <br/>
        /// Input: BaseRequest &lt; int &gt;
        /// <br/>
        /// Output: TDResponse       Not: islem basarili ise haserror 'false' doner
        /// </remarks>
        [LoginRequired]
        [HttpPost("BuyHeroByHeroId")]
        public async Task<TDResponse> BuyHeroByHeroId([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _heroService.BuyHeroByHeroId(req, user);
        }        
        

    }
}