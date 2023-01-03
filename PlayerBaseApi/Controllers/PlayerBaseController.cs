using Microsoft.AspNetCore.Mvc;
using PlayerBaseApi.Entities;
using PlayerBaseApi.Interfaces;
using PlayerBaseApi.Models;
using PlayerBaseApi.Services;
using SharedLibrary.Models;
using SharedLibrary.Models.Loot;

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
        
        [HttpPost("GetOtherPlayersBaseInfo")]
        public async Task<TDResponse<PlayerBaseInfoDTO>> GetOtherPlayersBaseInfo([FromBody] BaseRequest<long> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetOtherPlayersBaseInfo(req);
        }

        //[OnlyApps]
        [HttpPost("UpdateOrCreatePlayerBaseInfo")]
        public async Task<TDResponse> UpdateOrCreatePlayerBaseInfo([FromBody] BaseRequest<PlayerBaseInfoDTO> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.UpdateOrCreatePlayerBaseInfo(req);
        }

        //[OnlyApps]
        [HttpPost("GetCityShields")]
        public async Task<TDResponse<List<long>>> GetCityShields([FromBody] BaseRequest<List<long>> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetCityShields(req);
        }

        [LoginRequired]
        [HttpPost("UpgradeBuildingInfo")]
        public async Task<TDResponse<BuildingUpgradeTimeDTO>> UpgradeBuildingInfo([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.UpgradeBuildingInfo(req, user);
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

        /// <summary>
        /// Upgrade islemi devam eden binalarin upgrade islemini hizlandirici kullanarak hizlandirmak icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// SpeedUpRequest.GenericId = BuildingTypeId degeri
        /// <br/>
        /// SpeedUpRequest.ItemId = hizlandirici icin kullanilacak itemin idsi
        /// <br/>
        /// SpeedUpRequest.Count = kullanilacak itemin sayisi
        /// <br/>
        /// Input: BaseRequest &lt; SpeedUpRequest &gt;
        /// <br/>
        /// Output: TDResponse &lt; string &gt;       Not: hizlandirma sonrasi yeni UpgradeEndDate degerini doner
        /// </remarks>
        [LoginRequired]
        [HttpPost("SpeedUpUpgradeBuilding")]
        public async Task<TDResponse<string>> SpeedUpUpgradeBuilding([FromBody] BaseRequest<SpeedUpRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SpeedUpUpgradeBuilding(req, user);
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
        [Obsolete("deprecated", true)]
        public async Task<TDResponse<CollectBaseResponse>> CollectBaseResources([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.CollectBaseResources(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("GetReadyResearchNodes")]
        public async Task<TDResponse<List<int>>> GetReadyResearchNodes([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetReadyResearchNodes(req, user);
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

        /// <summary>
        /// Upgrade islemi devam eden research nodelari hizlandirici kullanarak hizlandirmak icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// SpeedUpRequest.GenericId = researchNodeId degeri
        /// <br/>
        /// SpeedUpRequest.ItemId = hizlandirici icin kullanilacak itemin idsi
        /// <br/>
        /// SpeedUpRequest.Count = kullanilacak itemin sayisi
        /// <br/>
        /// Input: BaseRequest &lt; SpeedUpRequest &gt;
        /// <br/>
        /// Output: TDResponse &lt; string &gt;       Not: hizlandirma sonrasi yeni upgradeEndDate degerini doner
        /// </remarks>
        [LoginRequired]
        [HttpPost("SpeedUpResearchNodeUpgrade")]
        public async Task<TDResponse<string>> SpeedUpResearchNodeUpgrade([FromBody] BaseRequest<SpeedUpRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SpeedUpResearchNodeUpgrade(req, user);
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

        /// <summary>
        /// devam eden prisoner training islemini hizlandirici kullanarak hizlandirmak icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// SpeedUpRequest.ItemId = hizlandirici icin kullanilacak itemin idsi
        /// <br/>
        /// SpeedUpRequest.Count = kullanilacak itemin sayisi
        /// <br/>
        /// SpeedUpRequest.GenericId = 0 gonderin
        /// <br/>
        /// Input: BaseRequest &lt; SpeedUpRequest &gt;
        /// <br/>
        /// Output: TDResponse &lt; string &gt;       Not: hizlandirma sonrasi yeni trainingDoneDate degerini doner
        /// </remarks>
        [LoginRequired]
        [HttpPost("SpeedUpPrisonerTraining")]
        public async Task<TDResponse<string>> SpeedUpPrisonerTraining([FromBody] BaseRequest<SpeedUpRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SpeedUpPrisonerTraining(req, user);
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
        [HttpPost("GetActiveLootRuns")]
        public async Task<TDResponse<List<PlayerHeroLootDTO>>> GetActiveLootRuns([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetActiveLootRuns(req, user);
        }          
        
        [LoginRequired]
        [HttpPost("GetActiveLootRunsForSocket")]
        public async Task<TDResponse<LootRunResponse>> GetActiveLootRunsForSocket([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetActiveLootRunsForSocket(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("OpenCloseAutoRun")]
        public async Task<TDResponse> OpenCloseAutoRun([FromBody] BaseRequest<SendLootRunRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.OpenCloseAutoRun(req, user);
        }        
        
        [LoginRequired]
        [HttpPost("GetLootRunPrediction")]
        public async Task<TDResponse<LootRunPredictionInfo>> GetLootRunPrediction([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetLootRunPrediction(req, user);
        }
                
        [LoginRequired]
        [HttpPost("SendLootRun")]
        public async Task<TDResponse> SendLootRun([FromBody] BaseRequest<SendLootRunRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SendLootRun(req, user);
        }

        /// <summary>
        /// devam eden lotrun islemini hizlandirici kullanarak hizlandirmak icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// SpeedUpRequest.ItemId = hizlandirici icin kullanilacak itemin idsi
        /// <br/>
        /// SpeedUpRequest.Count = kullanilacak itemin sayisi
        /// <br/>
        /// SpeedUpRequest.GenericId = lootrundaki heronun idsi
        /// <br/>
        /// Input: BaseRequest &lt; SpeedUpRequest &gt;
        /// <br/>
        /// Output: TDResponse &lt; string &gt;       Not: hizlandirma sonrasi yeni operationenddate degerini doner
        /// </remarks>
        [LoginRequired]
        [HttpPost("SpeedUpLootRun")]
        [Obsolete("deprecated", true)]
        public async Task<TDResponse<string>> SpeedUpLootRun([FromBody] BaseRequest<SpeedUpRequest> req)
        {
            //var user = (HttpContext.Items["User"] as UserDto);
            //req.SetUser(user.Id);
            //req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            //return await _playerBaseService.SpeedUpLootRun(req, user);
            return new TDResponse<string>();
        }

        [LoginRequired]
        [HttpPost("LootRunDoneRequest")]
        public async Task<TDResponse<LootRunDoneInfoDTO>> LootRunDoneRequest([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.LootRunDoneRequest(req, user);
        }
                
        [LoginRequired]
        [HttpPost("GetHospitalInfo")]
        public async Task<TDResponse<PlayerHospitalDTO>> GetHospitalInfo([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetHospitalInfo(req, user);
        }

        [LoginRequired]
        [HttpPost("HealingRequest")]
        public async Task<TDResponse> HealingRequest([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.HealingRequest(req, user);
        }

        /// <summary>
        /// devam eden yaralilari iyilestirme islemini hizlandirici kullanarak hizlandirmak icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// SpeedUpRequest.ItemId = hizlandirici icin kullanilacak itemin idsi
        /// <br/>
        /// SpeedUpRequest.Count = kullanilacak itemin sayisi
        /// <br/>
        /// SpeedUpRequest.GenericId = 0 gonderin
        /// <br/>
        /// Input: BaseRequest &lt; SpeedUpRequest &gt;
        /// <br/>
        /// Output: TDResponse &lt; string &gt;       Not: hizlandirma sonrasi yeni operationenddate degerini doner
        /// </remarks>
        [LoginRequired]
        [HttpPost("SpeedUpHealing")]
        public async Task<TDResponse<string>> SpeedUpHealing([FromBody] BaseRequest<SpeedUpRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SpeedUpHealing(req, user);
        }

        [LoginRequired]
        [HttpPost("HealingDoneRequest")]
        public async Task<TDResponse<int>> HealingDoneRequest([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.HealingDoneRequest(req, user);
        }

        /// <summary>
        /// Get all items in market
        /// </summary>
        [LoginRequired]
        [HttpPost("GetMarket")]
        public async Task<TDResponse<MarketDTO>> GetMarket([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetMarket(req, user);
        }

        /// <summary>
        /// Buy MarketItem via MarketItemId
        /// </summary>
        [LoginRequired]
        [HttpPost("BuyMarketItem")]
        public async Task<TDResponse> BuyMarketItem([FromBody] BaseRequest<BuyMarketItemRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.BuyMarketItem(req, user);
        }


        /// <summary>
        /// GetInventory
        /// </summary>
        [LoginRequired]
        [HttpPost("GetInventory")]
        public async Task<TDResponse<InventoryDTO>> GetInventory([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetInventory(req, user);
        }


        /// <summary>
        /// Get dialog input: 'BaseRequest&lt;string&gt;' , output: 'TDResponse&lt;List&lt;DialogDTO&gt;&gt;'
        /// </summary>
        [LoginRequired]
        [HttpPost("GetDialogByCodeName")]
        public async Task<TDResponse<List<DialogDTO>>> GetDialogByCodeName([FromBody] BaseRequest<string> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetDialogByCodeName(req, user);
        }

        /// <summary>
        /// Kullanilacak itemin idsi ve sayisi(count) gönderilir. input: 'BaseRequest&lt;UseItemRequest&gt;' , output: 'TDResponse'
        /// </summary>
        [LoginRequired]
        [HttpPost("UseItem")]
        public async Task<TDResponse> UseItem([FromBody] BaseRequest<UseItemRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.UseItem(req, user);
        }


        /// <summary>
        /// Oyuncu envanterinde bulunan speedup itemlarini getirir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse&lt; List &lt; UsableItemDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetPlayersSpeedUpItems")]
        public async Task<TDResponse<List<UsableItemDTO>>> GetPlayersSpeedUpItems([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetPlayersSpeedUpItems(req, user);
        }


        /// <summary>
        /// Training islemi bitmis trooplari toplamayi saglar
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse&lt; CollectTroopResponse &gt; NOT: islem sonrasi kazanilan troop sayisini ve cesitli bilgileri doner
        /// </remarks>
        [LoginRequired]
        [HttpPost("CollectTroopsFromBarracks")]
        public async Task<TDResponse<CollectTroopResponse>> CollectTroopsFromBarracks([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.CollectTroopsFromBarracks(req, user);
        }


        /// <summary>
        /// Player troop bilgisini doner
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse&lt; PlayerTroopInfoDTO &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetPlayerTroopInfo")]
        public async Task<TDResponse<PlayerTroopInfoDTO>> GetPlayerTroopInfo([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetPlayerTroopInfo(req, user);
        }
        
        /// <summary>
        /// Player troop bilgisini doner
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse&lt; PlayerTroopInfoDTOV2 &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetPlayerTroopInfoV2")]
        public async Task<TDResponse<PlayerTroopInfoDTOv2>> GetPlayerTroopInfoV2([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetPlayerTroopInfoV2(req, user);
        }


        /// <summary>
        /// Player gang ucretini duser. Yeterli gem yoksa hata doner
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse
        /// </remarks>
        [LoginRequired]
        [HttpPost("SpendGangCreateMoney")]
        public async Task<TDResponse> SpendGangCreateMoney([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SpendGangCreateMoney(req, user);
        }


        /// <summary>
        /// Playerin tutorial gorevlerini doner 
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest
        /// <br/>
        /// Output: TDResponse &lt; List &lt; PlayerTutorialQuestDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetPlayerTutorialQuests")]
        public async Task<TDResponse<List<PlayerTutorialQuestDTO>>> GetPlayerTutorialQuests([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetPlayerTutorialQuests(req, user);
        }


        /// <summary>
        /// Playerin towerdefensedeki wave sonu odullerini doner
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; int &gt;  NOT: oynanacak wave'in id degeri
        /// <br/>
        /// Output: TDResponse &lt; List &lt; PlayerItemDTO &gt; &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetTDWaveRewardsByWaveId")]
        public async Task<TDResponse<List<PlayerItemDTO>>> GetTDWaveRewardsByWaveId([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetTDWaveRewardsByWaveId(req, user);
        }


        /// <summary>
        /// Playerin towerdefensedeki wave sonu odullerini almak icin cagirilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; int &gt;  NOT: oynanacak wave'in id degeri
        /// <br/>
        /// Output: TDResponse ;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetTDWaveRewardsDoneByWaveId")]
        public async Task<TDResponse> GetTDWaveRewardsDoneByWaveId([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetTDWaveRewardsDoneByWaveId(req, user);
        }        
        
        
        /// <summary>
        /// Baska bir playerin base'ine scout yapmak icin cagirilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>Not: Test icin distance hesaplamasi yapilmaksizin 2 dk gidis 2 dk gelis olarak ayarlandi
        /// Input: BaseRequest &lt; ScoutRequest &gt;  NOT: user'in idsi ve distance degeri alinir
        /// <br/>
        /// Output: TDResponse &lt; ScoutDTO &gt; Not: suan data null donuyor ne donecegine karar veremedim
        /// </remarks>
        [LoginRequired]
        [HttpPost("ScoutPlayer")]
        public async Task<TDResponse<ScoutDTO>> ScoutPlayer([FromBody] BaseRequest<ScoutRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.ScoutPlayer(req, user);
        }             
        
        /// <summary>
        /// Baska bir playerin base'ine scout yapmak icin cagirilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>Not: Test icin distance hesaplamasi yapilmaksizin 2 dk gidis 2 dk gelis olarak ayarlandi
        /// Input: BaseRequest &lt; ScoutRequestV2 &gt;  NOT: user'in idsi ve distance degeri alinir
        /// <br/>
        /// Output: TDResponse &lt; ScoutDTO &gt; Not: suan data null donuyor ne donecegine karar veremedim
        /// </remarks>Task<TDResponse> ScoutPlayerV2(BaseRequest<ScoutRequestV2> req, UserDto user)
        [LoginRequired]
        [HttpPost("ScoutPlayerV2")]
        public async Task<TDResponse> ScoutPlayerV2([FromBody] BaseRequest<ScoutRequestV2> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.ScoutPlayerV2(req, user);
        }        
        
        
        /// <summary>
        /// Baska bir playerin base'ine toplu saldiri yapmak icin cagirilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>Not: Test icin distance hesaplamasi yapilmaksizin ayarlandi
        /// Input: BaseRequest &lt; CreateRallyRequest &gt;  NOT: user'in idsi, kullanilacak heronun idsi, asker sayisi, katilim bekleme suresi ve distance degeri alinir
        /// <br/>
        /// Output: TDResponse
        /// </remarks>
        [LoginRequired]
        [HttpPost("CreateRally")]
        public async Task<TDResponse> CreateRally([FromBody] BaseRequest<CreateRallyRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.CreateRally(req, user);
        }          
        
        /// <summary>
        /// Baska bir playerin base'ine yapilan toplu saldiriya katilmak icin cagirilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>Not: Test icin distance hesaplamasi yapilmaksizin ayarlandi
        /// Input: BaseRequest &lt; JoinRallyRequest &gt;  NOT: RallyId , kullanilacak heronun idsi, asker sayisi ve distance degeri alinir
        /// <br/>
        /// Output: TDResponse
        /// </remarks>
        [LoginRequired]
        [HttpPost("JoinRally")]
        public async Task<TDResponse> JoinRally([FromBody] BaseRequest<JoinRallyRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.JoinRally(req, user);
        }
                
        /// <summary>
        /// Baska bir playerin base'ine yapilan toplu saldiridan birini atmak icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// Input: BaseRequest &lt; long &gt;  NOT: RallyPart id
        /// <br/>
        /// Output: TDResponse
        /// </remarks>
        [LoginRequired]
        [HttpPost("KickRallyPart")]
        public async Task<TDResponse> KickRallyPart([FromBody] BaseRequest<long> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.KickRallyPart(req, user);
        }     
                        
        /// <summary>
        /// Baska bir playerin base'ine yapilan toplu saldiridan birini atmak icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// Input: BaseRequest &lt; long &gt;  NOT: RallyPart id
        /// <br/>
        /// Output: TDResponse
        /// </remarks>
        [LoginRequired]
        [HttpPost("AbortRally")]
        public async Task<TDResponse> AbortRally([FromBody] BaseRequest<long> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.AbortRally(req, user);
        }     
        
        /// <summary>
        /// Baska bir playerin base'ine saldiri yapmak icin cagirilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>Not: Test icin distance hesaplamasi yapilmaksizin 2 dk gidis 2 dk gelis olarak ayarlandi
        /// Input: BaseRequest &lt; AttackRequest &gt;  NOT: user'in idsi, kullanilacak heronun idsi, asker sayisi ve distance degeri alinir
        /// <br/>
        /// Output: TDResponse &lt; AttackInfoDTO &gt; Not: suan data null donuyor ne donecegine karar veremedim
        /// </remarks>
        [LoginRequired]
        [HttpPost("AttackPlayer")]
        public async Task<TDResponse<AttackInfoDTO>> AttackPlayer([FromBody] BaseRequest<AttackRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.AttackPlayer(req, user);
        }        
        
        
        /// <summary>
        /// Katilabilecegin rally listesini gormek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest 
        /// <br/>
        /// Output: TDResponse &lt; List &lt; RallyDTO &gt; &gt; 
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetRallyList")]
        public async Task<TDResponse<List<RallyDTO>>> GetRallyList([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetRallyList(req, user);
        }

        
        
        /// <summary>
        /// Active scout ve attack işlemlerini doner
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [LoginRequired]
        //[OnlyApps]
        [HttpPost("GetActiveInteractionsForSocket")]
        public async Task<TDResponse<InteractionsDTO>> GetActiveInteractionsForSocket([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetActiveInteractionsForSocket(req, user);
        }        
        
        /// <summary>
        /// AvatarId degistirmek icin kullanilir input olarak int alip tdresponse doner
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [LoginRequired]
        [HttpPost("ChangeAvatar")]
        public async Task<TDResponse> ChangeAvatar([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.ChangeAvatar(req, user);
        }       
                
        /// <summary>
        /// Player bio degistirmek icin kullanilir input olarak int alip tdresponse doner
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [LoginRequired]
        [HttpPost("ChangeBio")]
        public async Task<TDResponse> ChangeBio([FromBody] BaseRequest<string> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.ChangeBio(req, user);
        }       
        
        
        /// <summary>
        /// Base leveline gore sirali leaderboardu cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetBaseLevelLeaderBoard")]
        public async Task<TDResponse<Paging<LeaderBoardItem>>> GetBaseLevelLeaderBoard([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetBaseLevelLeaderBoard(req, user);
        }        
                
        /// <summary>
        /// Base leveline gore sirali leaderboardu cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [HttpPost("GetBaseLevelRankedByUserId")]
        public async Task<TDResponse<LeaderBoardItem>> GetBaseLevelRankedByUserId([FromBody] BaseRequest<long> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetBaseLevelRankedByUserId(req);
        }        
        
        /// <summary>
        /// Attacktaki Kill sayisine gore sirali leaderboardu cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetKillTroopLeaderBoard")]
        public async Task<TDResponse<Paging<LeaderBoardItem>>> GetKillTroopLeaderBoard([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetKillTroopLeaderBoard(req, user);
        }        
                
        /// <summary>
        /// Attacktaki Kill sayisine gore ranked cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [HttpPost("GetKillTroopRankedByUserId")]
        public async Task<TDResponse<LeaderBoardItem>> GetKillTroopRankedByUserId([FromBody] BaseRequest<long> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetKillTroopRankedByUserId(req);
        }        
        
        /// <summary>
        /// Savaslardan lootlananlara gore sirali leaderboardu cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetLootedScrapLeaderBoard")]
        public async Task<TDResponse<Paging<LeaderBoardItem>>> GetLootedScrapLeaderBoard([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetLootedScrapLeaderBoard(req, user);
        }
        
        /// <summary>
        /// Savaslardan lootlananlara gore ranked cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [HttpPost("GetLootedScrapRankedByUserId")]
        public async Task<TDResponse<LeaderBoardItem>> GetLootedScrapRankedByUserId([FromBody] BaseRequest<long> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetLootedScrapRankedByUserId(req);
        }        
        
        /// <summary>
        /// Attacktaki Kill sayisine gore sirali leaderboardu cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetDefenseKillLeaderBoard")]
        public async Task<TDResponse<Paging<LeaderBoardItem>>> GetDefenseKillLeaderBoard([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetDefenseKillLeaderBoard(req, user);
        }
                
        /// <summary>
        /// Attacktaki Kill sayisine gore ranked cekmek icin kullanilir
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [HttpPost("GetDefenseKillRankedByUserId")]
        public async Task<TDResponse<LeaderBoardItem>> GetDefenseKillRankedByUserId([FromBody] BaseRequest<long> req)
        {
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetDefenseKillRankedByUserId(req);
        }
        
        /// <summary>
        /// string olarak verilen actionin yapilip yapilmadigini kontrol icin cagirilir. Daha once kullanilmadiysa null doner.
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetFirstTimeTutorial")]
        public async Task<TDResponse<int?>> GetFirstTimeTutorial([FromBody] BaseRequest<string> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetFirstTimeTutorial(req,user);
        }        
        
        /// <summary>
        /// string olarak verilen actionin yapildigini kaydetmek icin cagirilir.
        /// </summary>
        /// <remarks>
        /// <br/>
        /// </remarks>
        [LoginRequired]
        [HttpPost("FirstTimeTutorialDone")]
        public async Task<TDResponse> FirstTimeTutorialDone([FromBody] BaseRequest<string> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.FirstTimeTutorialDone(req,user);
        }
                
        /// <summary>
        /// Baska bir gang uyesine reinforce gondermek icin kullanilir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; SupportUnitRequest &gt;
        /// <br/>
        /// Output: TDResponse
        /// </remarks>
        [LoginRequired]
        [HttpPost("SendSupportUnit")]
        public async Task<TDResponse> SendSupportUnit([FromBody] BaseRequest<SupportUnitRequest> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SendSupportUnit(req,user);
        }
        
        /// <summary>
        /// Idsi verilen reinforce islemini geri cagirmak icin kullanilir.
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; long &gt;
        /// <br/>
        /// Output: TDResponse
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetSupportUnitBackById")]
        public async Task<TDResponse> GetSupportUnitBackById([FromBody] BaseRequest<long> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetSupportUnitBackById(req,user);
        }
        
        /// <summary>
        /// playerin scout level ve spy bilgisini doner
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest 
        /// <br/>
        /// Output: TDResponse &lt; PlayerScoutDTO &gt;
        /// </remarks>
        [LoginRequired]
        [HttpPost("GetScoutInfo")]
        public async Task<TDResponse<PlayerScoutDTO>> GetScoutInfo([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.GetScoutInfo(req, user);
        }

        /// <summary>
        /// player spy egitimi baslatmak yapmak icin kullanir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest &lt; int &gt; not:egitilecek spy sayisi
        /// <br/>
        /// Output: TDResponse 
        /// </remarks>
        [LoginRequired]
        [HttpPost("SpyTrainingRequest")]
        public async Task<TDResponse> SpyTrainingRequest([FromBody] BaseRequest<int> req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SpyTrainingRequest(req, user);
        }
        
        /// <summary>
        /// player egitim suresi dolmus spylari birligine eklemek icin kullanir
        /// </summary>
        /// <remarks>
        /// ### DETAILS ###
        /// <br/>
        /// <br/>
        /// Input: BaseRequest 
        /// <br/>
        /// Output: TDResponse &lt; int &gt; not:egitilen spy sayisi
        /// </remarks>
        [LoginRequired]
        [HttpPost("SpyTrainingDoneRequest")]
        public async Task<TDResponse<int>> SpyTrainingDoneRequest([FromBody] BaseRequest req)
        {
            var user = (HttpContext.Items["User"] as UserDto);
            req.SetUser(user.Id);
            req.SetIp(HttpContext.Connection.RemoteIpAddress?.ToString());
            return await _playerBaseService.SpyTrainingDoneRequest(req, user);
        }
        
    }
}