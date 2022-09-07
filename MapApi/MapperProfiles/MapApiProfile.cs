using AutoMapper;
using MapApi.Entities;
using MapApi.Models;

namespace MapApi.MapperProfiles
{
    public class MapApiProfile : Profile
    {
        public MapApiProfile()
        {
            CreateMap<MapItemType, MapItemTypeDTO>();
        }

    }
}
