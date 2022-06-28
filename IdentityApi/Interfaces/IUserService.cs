using IdentityApi.Models;
using IdentityApi.Helpers;

namespace IdentityApi.Interfaces
{
    public interface IUserService    
    {
        //Task<WGResponse<Paging<UserDto>>> GetUserList(Paging pagingParameters);
        Task<TDResponse<UserDto>> GetUserById(long id);
        Task<TDResponse> AddUser(UserRequest userRequest);
        //Task<WGResponse> DeleteUserById(int id);
        Task<TDResponse<AuthenticateResponse>> Login(AuthenticateRequest model);
        //Task<WGResponse<UserDto>> GetUserProfile(long id);
        //Task<WGResponse> UpdateUser(UserDto userDto);

    }
}