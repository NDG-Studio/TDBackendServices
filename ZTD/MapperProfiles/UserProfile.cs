using AutoMapper;
using ZTD.Models;
using ZTD.Entities;
using SharedLibrary.Models;
namespace ZTD.MapperProfiles
{
    public class UserProfile : Profile
    {

        public UserProfile(){

            CreateMap<User, UserDto>();

            CreateMap<UserRequest,User>();

        }

    }
}