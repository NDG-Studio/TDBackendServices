using IdentityApi.Models;
using SharedLibrary.Models;

namespace IdentityApi.Interfaces
{
    public interface IUserService    
    {
        Task<TDResponse<UserDto>> GetUserById(long id);
        Task<TDResponse<long>> SignInRequest(UserRequest userRequest);
        Task<TDResponse> ActivateUser(long userId, string token);
        Task<TDResponse> ResendToken(long userId);
        Task<TDResponse<UserDto>> CheckToken(string token);
        Task<TDResponse<AuthenticateResponse>> Login(AuthenticateRequest model);

    }
}