using SharedLibrary.Models;
using WebSocket.Models;

namespace WebSocket.Interfaces
{
    public interface IGangService
    {
        Task<TDResponse> CreateGang(BaseRequest<CreateGangRequest> req, UserDto user, string token);
        Task<TDResponse<GangInfo>> GetGangInfo(BaseRequest<long?> req, UserDto user);
        Task<TDResponse> SendGangInvitation(BaseRequest<long> req, UserDto user);
    }
}
