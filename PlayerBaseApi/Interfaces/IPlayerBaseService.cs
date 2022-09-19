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
        Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<PlayerBasePlacementDTO>> UpgradeBuildingDoneRequest(BaseRequest<int> req, UserDto user);
        Task<TDResponse<CollectBaseResponse>> CollectBaseResources(BaseRequest req, UserDto user);
        Task<TDResponse<List<ResearchTableDTO>>> GetResearchTable(BaseRequest req, UserDto user);
    }
}
