using PlayerBaseApi.Models;
using SharedLibrary.Models;

namespace PlayerBaseApi.Interfaces
{
    public interface IPlayerBaseService
    {
        Task<TDResponse<List<PlayerBasePlacementDTO>>> GetBuildings(BaseRequest req, UserDto user);
        Task<TDResponse<List<BuildingTypeDTO>>> GetBuildingTypes(BaseRequest req, UserDto user);
        Task<TDResponse> AddPlayerBaseBuilding(BaseRequest<PlayerBaseBuildingRequest> req, UserDto user);
        Task<TDResponse> MovePlayerBuilding(BaseRequest<PlayerBaseBuildingRequest> req, UserDto user);
        Task<TDResponse<PlayerBaseInfoDTO>> GetPlayerBaseInfo(BaseRequest req, UserDto user);
        Task<TDResponse<PlayerBaseInfoDTO>> UpdateOrCreatePlayerBaseInfo(BaseRequest<PlayerBaseInfoDTO> req, UserDto user);
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
        Task<TDResponse> OpenCloseAutoRun(BaseRequest<SendLootRunRequest> req, UserDto user);
        Task<TDResponse<LootRunPredictionInfo>> GetLootRunPrediction(BaseRequest<int> req, UserDto user);
        Task<TDResponse> SendLootRun(BaseRequest<SendLootRunRequest> req, UserDto user);
        Task<TDResponse<LootRunDoneInfoDTO>> LootRunDoneRequest(BaseRequest<int> req, UserDto user);

        Task<TDResponse<PlayerHospitalDTO>> GetHospitalInfo(BaseRequest req, UserDto user);
        Task<TDResponse> HealingRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<int>> HealingDoneRequest(BaseRequest req, UserDto user);

        Task<TDResponse<MarketDTO>> GetMarket(BaseRequest req, UserDto user);
        Task<TDResponse> BuyMarketItem(BaseRequest<BuyMarketItemRequest> req, UserDto user);
        Task<TDResponse<InventoryDTO>> GetInventory(BaseRequest req, UserDto user);

        Task<TDResponse<List<DialogDTO>>> GetDialogByCodeName(BaseRequest<string> req, UserDto user);

        Task<TDResponse> UseItem(BaseRequest<UseItemRequest> req, UserDto user);
        Task<TDResponse<string>> SpeedUpResearchNodeUpgrade(BaseRequest<SpeedUpRequest> req, UserDto user);
        Task<TDResponse<string>> SpeedUpPrisonerTraining(BaseRequest<SpeedUpRequest> req, UserDto user);
        Task<TDResponse<List<PlayerItemDTO>>> GetPlayersSpeedUpItems(BaseRequest req, UserDto user);
        Task<TDResponse<string>> SpeedUpLootRun(BaseRequest<SpeedUpRequest> req, UserDto user);
        Task<TDResponse<string>> SpeedUpHealing(BaseRequest<SpeedUpRequest> req, UserDto user);
        Task<TDResponse<CollectTroopResponse>> CollectTroopsFromBarracks(BaseRequest req, UserDto user);
        Task<TDResponse<PlayerTroopInfoDTO>> GetPlayerTroopInfo(BaseRequest req, UserDto user);
    }
}
