using AutoMapper;
using PlayerBaseApi.Models;
using PlayerBaseApi.Entities;
using SharedLibrary.Models.Loot;
using SharedLibrary.Models;

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


            CreateMap<BuildingUpgradeCondition, BuildingUpgradeConditionDTO>()
                .ForMember(dest => dest.PrereqBuildingTypeName, operations => operations
                .MapFrom(
                    source => source.PrereqBuildingType != null ? source.PrereqBuildingType.Name : null));


            CreateMap<BuildingUpgradeTime, BuildingUpgradeTimeDTO>();
            CreateMap<PlayerBaseInfo, PlayerBaseInfoDTO>().ForMember(dest => dest.LastBaseCollect, operations => operations
                .MapFrom(
                    source => source.LastBaseCollect != null ? source.LastBaseCollect.ToString() : null));

            CreateMap<ResearchTable, ResearchTableDTO>();
            CreateMap<ResearchNode, ResearchNodeDTO>();
            CreateMap<ResearchNodeUpgradeNecessaries, ResearchNodeUpgradeNecessariesDTO>();
            CreateMap<ResearchNodeUpgradeCondition, ResearchNodeUpgradeConditionDTO>()
                .ForMember(dest => dest.ResearchNodeName, operations => operations
                .MapFrom(
                    source => source.ResearchNode != null ? source.ResearchNode.Name : null))
                .ForMember(dest => dest.BuildingTypeName, operations => operations
                .MapFrom(
                    source => source.BuildingType != null ? source.BuildingType.Name : null))
                .ForMember(dest => dest.ImageUrl, operations => operations
                .MapFrom(
                    source => source.BuildingType != null ? source.BuildingType.BuildUrl : (source.ResearchNode != null ? source.ResearchNode.ThumbnailUrl : null)));

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
                .ForMember(dest => dest.OperationStartDate, operations => operations
                .MapFrom(
                    source => source.OperationStartDate != null ? source.OperationStartDate.ToString() : null))                
                .ForMember(dest => dest.AutoLootRunEndDate, operations => operations
                .MapFrom(
                    source => source.AutoLootRunEndDate != null ? source.AutoLootRunEndDate.ToString() : null))
                .ForMember(dest => dest.Hero, operations => operations
                .MapFrom(
                    source => source.PlayerHero.Hero));

            CreateMap<PlayerHospital, PlayerHospitalDTO>()
                .ForMember(dest => dest.HealingDoneDate, operations => operations
                .MapFrom(
                    source => source.HealingDoneDate != null ? source.HealingDoneDate.ToString() : null));

            CreateMap<PlayerScout, PlayerScoutDTO>()
                .ForMember(dest => dest.TrainingDoneDate, operations => operations
                .MapFrom(
                    source => source.TrainingDoneDate != null ? source.TrainingDoneDate.ToString() : null));

            CreateMap<HospitalLevel, HospitalLevelDTO>();
            CreateMap<MarketItem, UsableItemDTO>();


            CreateMap<MarketItem, MarketItemDTO>();
            CreateMap<Item, ItemDTO>()
                .ForMember(dest => dest.ItemTypeName, operations => operations
                .MapFrom(
                    source => source.ItemType.Name))
                .ForMember(dest => dest.IsConsumable, operations => operations
                .MapFrom(
                    source => source.ItemType.IsConsumable));
            CreateMap<PlayerItem, PlayerItemDTO>();
            CreateMap<PlayerTDReward, PlayerItemDTO>();

            CreateMap<Dialog, DialogDTO>()
                .ForMember(dest => dest.Texts, operations => operations
                .MapFrom(
                    source => source.Text.Split("_,_",StringSplitOptions.None).ToList()));

            CreateMap<PlayerTroop, PlayerTroopInfoDTO>()
                .ForMember(dest => dest.LastTroopCollect, operations => operations
                .MapFrom(
                    source => source.LastTroopCollect != null ? source.LastTroopCollect.ToString() : null));
            
            CreateMap<PlayerTroop, PlayerTroopInfoDTOv2>()
                .ForMember(dest => dest.LastTroopCollect, operations => operations
                .MapFrom(
                    source => source.LastTroopCollect != null ? source.LastTroopCollect.ToString() : null));

        }

    }
}