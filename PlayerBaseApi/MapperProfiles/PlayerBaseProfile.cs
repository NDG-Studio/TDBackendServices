using AutoMapper;
using PlayerBaseApi.Models;
using PlayerBaseApi.Entities;
namespace PlayerBaseApi.MapperProfiles
{
    public class PlayerBaseProfile : Profile
    {

        public PlayerBaseProfile(){

            CreateMap<PlayerBasePlacement, PlayerBasePlacementDTO>()
                .ForMember(dest => dest.UpdateEndDate, operations => operations
                .MapFrom(
                    source => source.UpdateEndDate != null ? source.UpdateEndDate.ToString() : null));

            CreateMap<BuildingType, BuildingTypeDTO>();
            CreateMap<PlayerBaseInfo, PlayerBaseInfoDTO>().ForMember(dest => dest.LastBaseCollect, operations => operations
                .MapFrom(
                    source => source.LastBaseCollect != null ? source.LastBaseCollect.ToString() : null));

            CreateMap<ResearchTable, ResearchTableDTO>();
            CreateMap<ResearchNode, ResearchNodeDTO>();
            CreateMap<ResearchNodeUpgradeNecessaries, ResearchNodeUpgradeNecessariesDTO>();


        }

    }
}