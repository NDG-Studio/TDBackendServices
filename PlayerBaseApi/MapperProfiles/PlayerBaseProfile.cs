using AutoMapper;
using PlayerBaseApi.Models;
using PlayerBaseApi.Entities;
namespace PlayerBaseApi.MapperProfiles
{
    public class PlayerBaseProfile : Profile
    {

        public PlayerBaseProfile()
        {

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

            CreateMap<PlayerPrison, PlayerPrisonDTO>()
                .ForMember(dest => dest.TrainingDoneDate, operations => operations
                .MapFrom(
                    source => source.TrainingDoneDate != null ? source.TrainingDoneDate.ToString() : null));

            CreateMap<PrisonLevel, PrisonLevelDTO>();
            CreateMap<Buff, BuffDTO>();
            CreateMap<PlayerHeroLoot, PlayerHeroLootDTO>()
                .ForMember(dest => dest.OperationEndDate, operations => operations
                .MapFrom(
                    source => source.OperationEndDate != null ? source.OperationEndDate.ToString() : null))
                .ForMember(dest => dest.Hero, operations => operations
                .MapFrom(
                    source => source.PlayerHero.Hero));


        }

    }
}