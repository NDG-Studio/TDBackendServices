using AutoMapper;
using ZTD.Models;
using ZTD.Entities;
namespace ZTD.MapperProfiles
{
    public class TdProfile : Profile
    {

        public TdProfile(){

            CreateMap<ProgressDTO, UserProgressHistory>();
            CreateMap<Chapter, ChapterInfoDTO>();
            CreateMap<Wave, WaveDTO>();
            CreateMap<WavePart, WavePartDTO>();
            CreateMap<Enemy, EnemyDTO>().ForMember(dest => dest.EnemyDetails, operations => operations
                .MapFrom(
                    source => source.EnemyLevels));
            CreateMap<EnemyLevel, EnemyDetailDTO>().ForMember(dest => dest.EnemyLevelId, operations => operations
                .MapFrom(
                    source => source.Id));
            CreateMap<Tower, TowerDTO>();
            CreateMap<TowerLevel, TowerLevelDTO>();
            CreateMap<Level, LevelDTO>();
            CreateMap<Level, LevelInfoDTO>();
            CreateMap<TowerProgressDTO, TowerProgress>();
            CreateMap<EnemyKillDTO, EnemyKill>();
            CreateMap<TableChanges, TableChangesDTO>();
            CreateMap<Item, ItemDTO>();
            CreateMap<PlayerItem, PlayerItemDTO>();
            CreateMap<ChestType, ChestTypeDTO>();
            CreateMap<Chest, ChestDTO>().ForMember(dest => dest.OpenDuration, operations => operations
                .MapFrom(
                    source => source.OpenDuration.ToString()));
            CreateMap<LevelChestChance, LevelChestChanceDTO>();
            CreateMap<LevelGift, LevelGiftDTO>();
            CreateMap<PlayerChest, PlayerChestDTO>()
                .ForMember(dest => dest.OpenFinishDate, operations => operations
                .MapFrom(source => source.OpenFinishDate.ToString()))
                .ForMember(dest => dest.OpenStartDate, operations => operations
                    .MapFrom(source => source.OpenStartDate.ToString()));


        }

    }
}