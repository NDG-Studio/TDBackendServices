using PlayerBaseApi.Models;
using SharedLibrary.Models;
using SharedLibrary.Models.Loot;

namespace PlayerBaseApi.Interfaces
{
    public interface IPlayerBaseService
    {
        Task<TDResponse<List<PlayerBasePlacementDTO>>> GetBuildings(BaseRequest req, UserDto user);
        Task<TDResponse<List<BuildingTypeDTO>>> GetBuildingTypes(BaseRequest req, UserDto user);
        Task<TDResponse> AddPlayerBaseBuilding(BaseRequest<PlayerBaseBuildingRequest> req, UserDto user);
        Task<TDResponse> MovePlayerBuilding(BaseRequest<PlayerBaseBuildingRequest> req, UserDto user);
        Task<TDResponse<PlayerBaseInfoDTO>> GetPlayerBaseInfo(BaseRequest req, UserDto user);
        Task<TDResponse<PlayerBaseInfoDTO>> UpdateOrCreatePlayerBaseInfo(BaseRequest<PlayerBaseInfoDTO> req);
        Task<TDResponse<BuildingUpgradeTimeDTO>> UpgradeBuildingInfo(BaseRequest<int> req, UserDto user);
        Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<string>> SpeedUpUpgradeBuilding(BaseRequest<SpeedUpRequest> req, UserDto user);
        Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingDoneRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<CollectBaseResponse>> CollectBaseResources(BaseRequest req, UserDto user);

        Task<TDResponse<List<int>>> GetReadyResearchNodes(BaseRequest req, UserDto user);
        Task<TDResponse<List<ResearchTableDTO>>> GetResearchTable(BaseRequest req, UserDto user);
        Task<TDResponse<ResearchNodeUpgradeNecessariesDTO>> GetResearchNodeUpgradeNecessariesByNodeId(BaseRequest<int> req, UserDto user);
        Task<TDResponse> UpgradeResearchNode(BaseRequest<int> req, UserDto user);
        Task<TDResponse> UpgradeResearchNodeDone(BaseRequest<int> req, UserDto user);

        Task<TDResponse<PlayerPrisonDTO>> GetPrisonInfo(BaseRequest req, UserDto user);
        Task<TDResponse<int>> ExecutePrisoners(BaseRequest<int> req, UserDto user);
        Task<TDResponse> PrisonerTrainingRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<int>> PrisonerTrainingDoneRequest(BaseRequest req, UserDto user);
        Task<TDResponse<List<PlayerHeroLootDTO>>> GetActiveLootRuns(BaseRequest req, UserDto user);
        Task<TDResponse<LootRunResponse>> GetActiveLootRunsForSocket(BaseRequest req, UserDto user);
        Task<TDResponse> OpenCloseAutoRun(BaseRequest<SendLootRunRequest> req, UserDto user);
        Task<TDResponse<LootRunPredictionInfo>> GetLootRunPrediction(BaseRequest<int> req, UserDto user);
        Task<TDResponse> SendLootRun(BaseRequest<SendLootRunRequest> req, UserDto user);
        Task<TDResponse<LootRunDoneInfoDTO>> LootRunDoneRequest(BaseRequest<int> req, UserDto user);

        Task<TDResponse<PlayerHospitalDTO>> GetHospitalInfo(BaseRequest req, UserDto user);
        Task<TDResponse> HealingRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<int>> HealingDoneRequest(BaseRequest req, UserDto user);
        Task<TDResponse<PlayerScoutDTO>> GetScoutInfo(BaseRequest req, UserDto user);
        Task<TDResponse> SpyTrainingRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<int>> SpyTrainingDoneRequest(BaseRequest req, UserDto user);

        Task<TDResponse<MarketDTO>> GetMarket(BaseRequest req, UserDto user);
        Task<TDResponse> BuyMarketItem(BaseRequest<BuyMarketItemRequest> req, UserDto user);
        Task<TDResponse<InventoryDTO>> GetInventory(BaseRequest req, UserDto user);

        Task<TDResponse<List<DialogDTO>>> GetDialogByCodeName(BaseRequest<string> req, UserDto user);

        Task<TDResponse> UseItem(BaseRequest<UseItemRequest> req, UserDto user);
        Task<TDResponse<string>> SpeedUpResearchNodeUpgrade(BaseRequest<SpeedUpRequest> req, UserDto user);
        Task<TDResponse<string>> SpeedUpPrisonerTraining(BaseRequest<SpeedUpRequest> req, UserDto user);
        Task<TDResponse<string>> SpeedUpLootRun(BaseRequest<SpeedUpRequest> req, UserDto user);
        Task<TDResponse<string>> SpeedUpHealing(BaseRequest<SpeedUpRequest> req, UserDto user);
        Task<TDResponse<CollectTroopResponse>> CollectTroopsFromBarracks(BaseRequest req, UserDto user);
        Task<TDResponse<PlayerTroopInfoDTO>> GetPlayerTroopInfo(BaseRequest req, UserDto user);
        Task<TDResponse<PlayerTroopInfoDTOv2>> GetPlayerTroopInfoV2(BaseRequest req, UserDto user);
        Task<TDResponse> SpendGangCreateMoney(BaseRequest req, UserDto user);
        Task<TDResponse<PlayerTutorialQuestDTO>> GetNextTutorialQuest(BaseRequest req, UserDto user);
        Task<TDResponse<List<PlayerTutorialQuestDTO>>> GetTutorialQuestList(BaseRequest req, UserDto user);
        Task<TDResponse> DoneTutorialQuest(BaseRequest<bool> req, UserDto user);
        Task<TDResponse> DoneTutorialQuestById(BaseRequest<DoneTutorialQuestRequest> req, UserDto user);
        Task<TDResponse<List<UsableItemDTO>>> GetPlayersSpeedUpItems(BaseRequest req, UserDto user);
        Task<TDResponse<List<PlayerItemDTO>>> GetTDWaveRewardsByWaveId(BaseRequest<int> req, UserDto user);
        Task<TDResponse> GetTDWaveRewardsDoneByWaveId(BaseRequest<int> req, UserDto user);
        Task<TDResponse<ScoutDTO>> ScoutPlayer(BaseRequest<ScoutRequest> req, UserDto user);
        Task<TDResponse> ScoutPlayerV2(BaseRequest<ScoutRequestV2> req, UserDto user);
        Task<TDResponse<AttackInfoDTO>> AttackPlayer(BaseRequest<AttackRequest> req, UserDto user);
        Task<TDResponse> CreateRally(BaseRequest<CreateRallyRequest> req, UserDto user);
        Task<TDResponse> JoinRally(BaseRequest<JoinRallyRequest> req, UserDto user);
        Task<TDResponse> KickRallyPart(BaseRequest<long> req, UserDto user);
        Task<TDResponse> AbortRally(BaseRequest<long> req, UserDto user);
        Task<TDResponse<List<RallyDTO>>> GetRallyList(BaseRequest req, UserDto user);
        Task<TDResponse<InteractionsDTO>> GetActiveInteractionsForSocket(BaseRequest req, UserDto user);
        Task<TDResponse> ChangeAvatar(BaseRequest<int> req, UserDto user);
        Task<TDResponse<Paging<LeaderBoardItem>>> GetBaseLevelLeaderBoard(BaseRequest<int> req, UserDto user);
        Task<TDResponse<LeaderBoardItem>> GetBaseLevelRankedByUserId(BaseRequest<long> req);
        Task<TDResponse> ChangeBio(BaseRequest<string> req, UserDto user);
        Task<TDResponse<PlayerBaseInfoDTO>> GetOtherPlayersBaseInfo(BaseRequest<long> req);
        Task<TDResponse<Paging<LeaderBoardItem>>> GetKillTroopLeaderBoard(BaseRequest<int> req, UserDto user);        
        Task<TDResponse<LeaderBoardItem>> GetKillTroopRankedByUserId(BaseRequest<long> req);        
        Task<TDResponse<Paging<LeaderBoardItem>>> GetLootedScrapLeaderBoard(BaseRequest<int> req, UserDto user);
        Task<TDResponse<LeaderBoardItem>> GetLootedScrapRankedByUserId(BaseRequest<long> req);
        Task<TDResponse<Paging<LeaderBoardItem>>> GetDefenseKillLeaderBoard(BaseRequest<int> req, UserDto user);
        Task<TDResponse<LeaderBoardItem>> GetDefenseKillRankedByUserId(BaseRequest<long> req);
        Task<TDResponse<int?>> GetFirstTimeTutorial(BaseRequest<string> req, UserDto user);
        Task<TDResponse> FirstTimeTutorialDone(BaseRequest<string> req, UserDto user);
        Task<TDResponse<List<long>>> GetCityShields(BaseRequest<List<long>> req);

        Task<TDResponse> SendSupportUnit(BaseRequest<SupportUnitRequest> req, UserDto user);
        Task<TDResponse> GetSupportUnitBackById(BaseRequest<long> req, UserDto user);
        Task<TDResponse<List<TowerLevelPair>>> GetActiveTowers(BaseRequest<long> req);
        Task<TDResponse<List<GateInfoDTO>>> GetGateInfo(BaseRequest req, UserDto user);
        Task<TDResponse<List<GateInfoDTO>>> GetGangGates(BaseRequest req, UserDto user);
    }
}
