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
        }

    }
}