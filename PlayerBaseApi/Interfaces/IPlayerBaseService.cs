﻿using PlayerBaseApi.Models;
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
        Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingDoneRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<CollectBaseResponse>> CollectBaseResources(BaseRequest req, UserDto user);
        Task<TDResponse<List<ResearchTableDTO>>> GetResearchTable(BaseRequest req, UserDto user);
        Task<TDResponse<ResearchNodeUpgradeNecessariesDTO>> GetResearchNodeUpgradeNecessariesByNodeId(BaseRequest<int> req, UserDto user);
        Task<TDResponse> UpgradeResearchNode(BaseRequest<int> req, UserDto user);
        Task<TDResponse> UpgradeResearchNodeDone(BaseRequest<int> req, UserDto user);

        Task<TDResponse<PlayerPrisonDTO>> GetPrisonInfo(BaseRequest req, UserDto user);
        Task<TDResponse<int>> ExecutePrisoners(BaseRequest<int> req, UserDto user);
        Task<TDResponse> PrisonerTrainingRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<int>> PrisonerTrainingDoneRequest(BaseRequest req, UserDto user);
        Task<TDResponse<List<PlayerHeroLootDTO>>> GetLootRuns(BaseRequest req, UserDto user);
        Task<TDResponse> SendLootRun(BaseRequest<int> req, UserDto user);
    }
}
