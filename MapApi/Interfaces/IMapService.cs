using MapApi.Models;
using SharedLibrary.Models;

namespace MapApi.Interfaces
{
    public interface IMapService
    {
        Task<TDResponse<List<MapItemTypeDTO>>> GetMapItemTypes(BaseRequest req, UserDto user);
        Task<TDResponse<MapItemDTO>> AddUserBase(BaseRequest<bool> isApe, UserDto user);
        Task<TDResponse> MoveUserBase(BaseRequest<MapItemDTO> req, UserDto user);
    }
}
