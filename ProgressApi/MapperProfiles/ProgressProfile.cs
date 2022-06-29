using AutoMapper;
using ProgressApi.Models;
using ProgressApi.Entities;
namespace ProgressApi.MapperProfiles
{
    public class ProgressProfile : Profile
    {

        public ProgressProfile(){

            CreateMap<ProgressDto, UserProgress>()
                .ForMember(dest => dest.LevelStartTime, operations => operations
                .MapFrom(
                    source => source.LevelStartTime != null ? DateTimeOffset.Parse(source.LevelStartTime) : DateTimeOffset.MinValue))
                .ForMember(dest => dest.LevelStartTime, operations => operations
                .MapFrom(
                    source => source.LevelEndTime != null ? DateTimeOffset.Parse(source.LevelEndTime) : DateTimeOffset.MinValue));


        }

    }
}