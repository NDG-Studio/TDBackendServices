using AutoMapper;
using WebSocket.Models;
using WebSocket.Entities;
namespace WebSocket.MapperProfiles
{
    public class WebSocketProfile : Profile
    {

        public WebSocketProfile(){

            CreateMap<News, NewsDTO>();
        }

    }
}