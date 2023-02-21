using AutoMapper;
using ZTD.Entities;
using ZTD.Models;

namespace ZTD.MapperProfiles
{
    public class DialogProfile : Profile
    {

        public DialogProfile(){

            CreateMap<DialogScene, DialogSceneDTO>();
            CreateMap<Dialog, DialogDTO>()
                .ForMember(dest => dest.Texts, operations => operations
                    .MapFrom(source => source.Text.Split("*,*",StringSplitOptions.None).ToList()));
        }

    }
}