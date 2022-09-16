using AutoMapper;
using PlayerBaseApi.Models;
using PlayerBaseApi.Entities;
namespace PlayerBaseApi.MapperProfiles
{
    public class HeroProfile : Profile
    {

        public HeroProfile(){

            CreateMap<Hero, HeroDTO>();
            CreateMap<PlayerHero, PlayerHeroDTO>()
                .ForMember(dest => dest.EndDate, operations => operations
                .MapFrom(
                    source => source.EndDate != null ? source.EndDate.ToString() : null));
            CreateMap<HeroLevelThreshold, HeroLevelThresholdDTO>();

            CreateMap<TalentTree, TalentTreeDTO>();
            CreateMap<TalentTreeNode, TalentTreeNodeDTO>();
        }

    }
}