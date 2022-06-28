using AutoMapper;
using IdentityApi.Models;
using IdentityApi.Entities;
namespace IdentityApi.MapperProfiles
{
    public class UserProfile : Profile
    {

        public UserProfile(){

            CreateMap<User, UserDto>();

            CreateMap<UserRequest,User>();

        }

    }
}