using IdentityApi.Models;
using SharedLibrary.Models;

namespace IdentityApi.Interfaces
{
    public interface IUserService    
    {
        Task<TDResponse<UserDto>> GetUserById(BaseRequest<long> req);
        Task<TDResponse<UserDto>> GetUserById(long id);
        Task<TDResponse<long>> SignInRequest(BaseRequest<UserRequest> req);
        Task<TDResponse> ActivateUser(BaseRequest<ActivationRequest> req);
        Task<TDResponse> ResendToken(BaseRequest<long> req);
        Task<TDResponse<UserDto>> CheckToken(string token);
        Task<TDResponse<AuthenticateResponse>> Login(BaseRequest<AuthenticateRequest> req);

    }
}