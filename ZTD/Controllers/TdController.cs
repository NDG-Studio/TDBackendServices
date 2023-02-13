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
        
        /// <summary>
        /// Towerlari ve levellerini detayli olarak cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; TowerDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetTowers")]
        public async Task<TDResponse<List<TowerDTO>>> GetTowers([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetTowers(req, user);
        }
                
        /// <summary>
        /// Enemyleri ve levellerini detayli olarak cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; EnemyDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetEnemyList")]
        public async Task<TDResponse<List<EnemyDTO>>> GetEnemyList([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetEnemyList(req, user);
        }
                
                
        /// <summary>
        /// itemleri detayli olarak cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; ItemDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetItems")]
        public async Task<TDResponse<List<ItemDTO>>> GetItems([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetItems(req, user);
        }
                        
                
        /// <summary>
        /// chestleri ve chesttypeleri detayli olarak cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; ChestTypeDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetChestTypes")]
        public async Task<TDResponse<List<ChestTypeDTO>>> GetChestTypes([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetChestTypes(req, user);
        }
                        
                
        /// <summary>
        /// playera ait chestleri detayli olarak cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; PlayerChestDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetPlayerChests")]
        public async Task<TDResponse<List<PlayerChestDTO>>> GetPlayerChests([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetPlayerChests(req, user);
        }
                        
                                
        /// <summary>
        /// playerin chest bilgisini setler ve son halini doner 
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; List &lt; PlayerChestDTO &gt; &gt;
        /// <br/>
        /// Output: TDResponse &lt; List &lt; PlayerChestDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("SetPlayerChests")]
        public async Task<TDResponse<List<PlayerChestDTO>>> SetPlayerChests([FromBody] BaseRequest<List<PlayerChestDTO>> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.SetPlayerChests(req, user);
        }                  
        
                
        /// <summary>
        /// playera ait itemlari detayli olarak cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; PlayerItemDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetPlayerItems")]
        public async Task<TDResponse<List<PlayerItemDTO>>> GetPlayerItems([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetPlayerItems(req, user);
        }
                        
                                
        /// <summary>
        /// playerin item bilgilerini setler ve son halini doner 
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; List &lt; PlayerItemDTO &gt; &gt;
        /// <br/>
        /// Output: TDResponse &lt; List &lt; PlayerItemDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("SetPlayerItems")]
        public async Task<TDResponse<List<PlayerItemDTO>>> SetPlayerItems([FromBody] BaseRequest<List<PlayerItemDTO>> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.SetPlayerItems(req, user);
        }
                        
                
        /// <summary>
        /// playerin currency bilgisini detayli olarak cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; PlayerVariableDTO &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetPlayerVariable")]
        public async Task<TDResponse<PlayerVariableDTO>> GetPlayerVariable([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetPlayerVariable(req, user);
        }
                         
                
        /// <summary>
        /// playerin currency bilgisini setler ve son halini doner 
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; PlayerVariableDTO &gt;
        /// <br/>
        /// Output: TDResponse &lt; PlayerVariableDTO &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("SetPlayerVariable")]
        public async Task<TDResponse<PlayerVariableDTO>> SetPlayerVariable([FromBody] BaseRequest<PlayerVariableDTO> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.SetPlayerVariable(req, user);
        }
        
        /// <summary>
        /// Geride kaldigi tablolar var mi kontrolu icin atilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; TableChangesDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetSyncStatus")]
        public async Task<TDResponse<List<TableChangesDTO>>> GetSyncStatus([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetSyncStatus(req, user);
        }
                
        /// <summary>
        /// researchle ilgili herseyi ceker
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; ResearchNodeDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetResearchNodes")]
        public async Task<TDResponse<List<ResearchNodeDTO>>> GetResearchNodes([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetResearchNodes(req, user);
        }
             
        
        /// <summary>
        /// playerin research durumunu doner
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; PlayerResearchNodeLevelDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetPlayerResearchNodeLevels")]
        public async Task<TDResponse<List<PlayerResearchNodeLevelDTO>>> GetPlayerResearchNodeLevels([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.GetPlayerResearchNodeLevels(req, user);
        }
        
        /// <summary>
        /// playerin research durumunu setler ve doner
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; List &lt; PlayerResearchNodeLevelDTO &gt; &gt;
        /// <br/>
        /// Output: TDResponse &lt; List &lt; PlayerResearchNodeLevelDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("SetPlayerResearchNodeLevels")]
        public async Task<TDResponse<List<PlayerResearchNodeLevelDTO>>> SetPlayerResearchNodeLevels([FromBody] BaseRequest<List<PlayerResearchNodeLevelDTO>> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.SetPlayerResearchNodeLevels(req, user);
        }
        
        /// <summary>
        /// Progress eklemek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; List &lt; ProgressDTO &gt; &gt;
        /// <br/>
        /// Output: TDResponse 
        /// </remarks>
        [LoginRequired]
        [HttpPost("AddProgressList")]
        public async Task<TDResponse> AddProgressList([FromBody] BaseRequest<List<ProgressDTO>> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _service.AddProgressList(req, user);
        }
        

    }
}