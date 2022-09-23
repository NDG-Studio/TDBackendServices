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

        [LoginRequired]
        [HttpPost("MovePlayerBuilding")]
        public async Task<TDResponse> MovePlayerBuilding([FromBody] BaseRequest<PlayerBaseBuildingRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.MovePlayerBuilding(req, user);
        }

        [LoginRequired]
        [HttpPost("GetPlayerBaseInfo")]
        public async Task<TDResponse<PlayerBaseInfoDTO>> GetPlayerBaseInfo([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetPlayerBaseInfo(req, user);
        }

        [LoginRequired]
        [HttpPost("UpdateOrCreatePlayerBaseInfo")]
        public async Task<TDResponse<PlayerBaseInfoDTO>> UpdateOrCreatePlayerBaseInfo([FromBody] BaseRequest<PlayerBaseInfoDTO> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.UpdateOrCreatePlayerBaseInfo(req, user);
        }

        [LoginRequired]
        [HttpPost("UpgradeBuildingRequest")]
        public async Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingRequest([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.UpgradeBuildingRequest(req, user);
        }

        [LoginRequired]
        [HttpPost("UpgradeBuildingDoneRequest")]
        public async Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingDoneRequest([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.UpgradeBuildingDoneRequest(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("CollectBaseResources")]
        public async Task<TDResponse<CollectBaseResponse>> CollectBaseResources([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.CollectBaseResources(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("GetResearchTable")]
        public async Task<TDResponse<List<ResearchTableDTO>>> GetResearchTable([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetResearchTable(req, user);
        }
        
        [LoginRequired]
        [HttpPost("GetResearchNodeUpgradeNecessariesByNodeId")]
        public async Task<TDResponse<ResearchNodeUpgradeNecessariesDTO>> GetResearchNodeUpgradeNecessariesByNodeId([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetResearchNodeUpgradeNecessariesByNodeId(req, user);
        }
        
        [LoginRequired]
        [HttpPost("UpgradeResearchNode")]
        public async Task<TDResponse> UpgradeResearchNode([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.UpgradeResearchNode(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("UpgradeResearchNodeDone")]
        public async Task<TDResponse> UpgradeResearchNodeDone([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.UpgradeResearchNodeDone(req, user);
        }        

        [LoginRequired]
        [HttpPost("GetPrisonInfo")]
        public async Task<TDResponse<PlayerPrisonDTO>> GetPrisonInfo([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetPrisonInfo(req, user);
        }

        [LoginRequired]
        [HttpPost("ExecutePrisoners")]
        public async Task<TDResponse<int>> ExecutePrisoners([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.ExecutePrisoners(req, user);
        }

        [LoginRequired]
        [HttpPost("PrisonerTrainingRequest")]
        public async Task<TDResponse> PrisonerTrainingRequest([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.PrisonerTrainingRequest(req, user);
        }

        [LoginRequired]
        [HttpPost("PrisonerTrainingDoneRequest")]
        public async Task<TDResponse<int>> PrisonerTrainingDoneRequest([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.PrisonerTrainingDoneRequest(req, user);
        }
        
        [LoginRequired]
        [HttpPost("GetLootRuns")]
        public async Task<TDResponse<List<PlayerHeroLootDTO>>> GetLootRuns([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetLootRuns(req, user);
        }
                
        [LoginRequired]
        [HttpPost("SendLootRun")]
        public async Task<TDResponse> SendLootRun([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SendLootRun(req, user);
        }

    }
}