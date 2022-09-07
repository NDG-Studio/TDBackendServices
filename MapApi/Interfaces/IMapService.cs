using MapApi.Models;
using SharedLibrary.Models;

namespace MapApi.Interfaces
{
    public interface IMapService
    {
        Task<TDResponse<List<MapItemTypeDTO>>> GetMapItemTypes(BaseRequest req, UserDto user);
    }
}
