using MapApi.Models;
using SharedLibrary.Models;

namespace MapApi.Interfaces
{
    public interface IMapService
    {
        Task<TDResponse<List<MapItemTypeDTO>>> GetMapItemTypes(BaseRequest req, UserDto user);
        Task<TDResponse<MapItemDTO>> AddUserBase(BaseRequest<bool> isApe, UserDto user);
        Task<TDResponse> MoveUserBase(BaseRequest<MapItemDTO> req, UserDto user);
        Task<TDResponse<List<MapInfoDto>>> GetMapByAreaIds(BaseRequest<List<int>> req, UserDto user);
        Task<TDResponse<List<InfoWithAreaDTO>>> GetMapByBoundBox(BaseRequest<BoundBox> req, UserDto user);
        Task<TDResponse<bool>> GetApeIsRecommended(BaseRequest req, UserDto user);
        Task<TDResponse<List<MapItemDTO>>> GetAllGates(BaseRequest isApe, UserDto user);
    }
}
