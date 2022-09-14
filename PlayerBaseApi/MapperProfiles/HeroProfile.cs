using AutoMapper;
using PlayerBaseApi.Models;
using PlayerBaseApi.Entities;
namespace PlayerBaseApi.MapperProfiles
{
    public class HeroProfile : Profile
    {

        public HeroProfile(){

            CreateMap<Hero, HeroDTO>();


        }

    }
}