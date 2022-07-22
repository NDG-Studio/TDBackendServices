using AutoMapper;
using ProgressApi.Models;
using ProgressApi.Entities;
namespace ProgressApi.MapperProfiles
{
    public class ProgressProfile : Profile
    {

        public ProgressProfile(){

            CreateMap<ProgressDto, UserProgress>()
                .ForMember(dest => dest.StageStartTime, operations => operations
                .MapFrom(
                    source => source.StageStartTime != null ? DateTimeOffset.Parse(source.StageStartTime) : DateTimeOffset.MinValue));

            CreateMap<Zombie, ZombieDto>();
            CreateMap<Tower, TowerDto>();
            CreateMap<Stage, StageDto>();
            CreateMap<TowerProgressDto, TowerProgress>();
            CreateMap<ZombieKillDto, ZombieKill>();
            CreateMap<UserProgress, StageStatusDto>()
                .ForMember(dest => dest.StageName, operations => operations.MapFrom(source => source.Stage!.Name))
                .ForMember(dest => dest.StageCode, operations => operations.MapFrom(source => source.Stage!.Code));
                
        }

    }
}