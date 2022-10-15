using AutoMapper;
using ProgressApi.Models;
using ProgressApi.Entities;
namespace ProgressApi.MapperProfiles
{
    public class ProgressProfile : Profile
    {

        public ProgressProfile(){

            CreateMap<ProgressDTO, UserProgressHistory>();

            CreateMap<Enemy, EnemyDTO>();
            CreateMap<Tower, TowerDTO>();
            CreateMap<TowerLevel, TowerLevelDTO>();
            CreateMap<Stage, StageDTO>();
            CreateMap<TowerProgressDTO, TowerProgress>();
            CreateMap<EnemyKillDTO, EnemyKill>();
            CreateMap<UserProgressHistory, StageStatusDTO>()
                .ForMember(dest => dest.StageName, operations => operations.MapFrom(source => source.Wave!.Name))
                .ForMember(dest => dest.StageCode, operations => operations.MapFrom(source => source.Wave!.Stage.Code));
            CreateMap<UserTowerPlace, UserTowerStatusDTO>()
                .ForMember(dest => dest.Name, operations => operations.MapFrom(source => source.TowerLevel.Tower.Name))
                .ForMember(dest => dest.TowerId, operations => operations.MapFrom(source => source.TowerLevel.TowerId))
                .ForMember(dest => dest.TowerLevelId, operations => operations.MapFrom(source => source.TowerLevelId))
                .ForMember(dest => dest.Level, operations => operations.MapFrom(source => source.TowerLevel.Level))
                .ForMember(dest => dest.Damage, operations => operations.MapFrom(source => source.TowerLevel.Damage))
                .ForMember(dest => dest.FireRate, operations => operations.MapFrom(source => source.TowerLevel.FireRate))
                .ForMember(dest => dest.Range, operations => operations.MapFrom(source => source.TowerLevel.Range));

        }

    }
}