using Microsoft.AspNetCore.Mvc;
using ZTD.Interfaces;
using ZTD.Models;
using SharedLibrary.Models;

namespace ZTD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TdController : ControllerBase
    {

        private readonly ILogger<TdController> _logger;
        private readonly ITdService _service;

        public TdController(ILogger<TdController> logger, ITdService service)
        {
            _logger = logger;
            _service = service;
        }
        
        
        /// <summary>
        /// Chapterin genel infosunu doner
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; ChapterInfoDTO &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetChapterInfo")]
        public async Task<TDResponse> GetChapterInfo([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetChapterInfo(req, user);
        }
        
        /// <summary>
        /// Levelleri detayli olarak wave ve wave parts bilgileri ile birlikte cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// BaseRequest icinde detayli oynanabilir verisi istenen levellerin idleri gonderilir
        /// <br/>
        /// Input: BaseRequest &lt; List &lt; int &gt; &gt;
        /// <br/>
        /// Output: TDResponse &lt; List &lt; LevelDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetLevels")]
        public async Task<TDResponse<List<LevelDTO>>> GetLevels([FromBody] BaseRequest<List<int>> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetLevels(req, user);
        }        
        

    }
}