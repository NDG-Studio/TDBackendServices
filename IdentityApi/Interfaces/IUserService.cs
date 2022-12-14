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
        Task<TDResponse<UserDto>> CheckToken(BaseRequest<string> token);
        Task<TDResponse<AuthenticateResponse>> Login(BaseRequest<AuthenticateRequest> req);
        Task<TDResponse<AuthenticateResponse>> LoginWithDeviceId(BaseRequest req);
        Task<TDResponse<long>> SignInRequestV2(BaseRequest<UserRequest> req);
        Task<TDResponse<AuthenticateResponse>> LoginWithFacebook(BaseRequest<string> req);
        Task<TDResponse<AuthenticateResponse>> LoginWithApple(BaseRequest<string> req);
        Task<TDResponse> TutorialDone(BaseRequest req, UserDto user);
        Task<TDResponse<string>> ChangeUsername(BaseRequest<string> req, UserDto user);
        Task<TDResponse> DeleteUserByUsername(BaseRequest<string> req,UserDto user);
    }
}