using AutoMapper;
using ProgressApi.Models;
using ProgressApi.Entities;
namespace ProgressApi.MapperProfiles
{
    public class ProgressProfile : Profile
    {

        public ProgressProfile(){

            CreateMap<ProgressDto, UserProgressHistory>()
                .ForMember(dest => dest.WaveStartTime, operations => operations
                .MapFrom(
                    source => source.WaveStartTime != null ? DateTimeOffset.Parse(source.WaveStartTime) : DateTimeOffset.MinValue));

            CreateMap<Enemy, EnemyDto>();
            CreateMap<Tower, TowerDto>();
            CreateMap<Stage, StageDto>();
            CreateMap<TowerProgressDto, TowerProgress>();
            CreateMap<EnemyKillDto, EnemyKill>();
            CreateMap<UserProgressHistory, StageStatusDto>()
                .ForMember(dest => dest.StageName, operations => operations.MapFrom(source => source.Wave!.Name))
                .ForMember(dest => dest.StageCode, operations => operations.MapFrom(source => source.Wave!.Stage.Code));
                
        }

    }
}