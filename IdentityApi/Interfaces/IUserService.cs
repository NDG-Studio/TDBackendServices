using IdentityApi.Models;
using SharedLibrary.Models;

namespace IdentityApi.Interfaces
{
    public interface IUserService    
    {
        Task<TDResponse<UserDto>> GetUserById(long id);
        Task<TDResponse> SignInRequest(UserRequest userRequest);
        Task<TDResponse<UserDto>> CheckToken(string token);
        Task<TDResponse<AuthenticateResponse>> Login(AuthenticateRequest model);

    }
}