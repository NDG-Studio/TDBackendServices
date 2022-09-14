using PlayerBaseApi.Models;
using SharedLibrary.Models;

namespace PlayerBaseApi.Interfaces
{
    public interface IHeroService
    {
        Task<TDResponse<List<HeroDTO>>> GetHeroTypes(BaseRequest req, UserDto user);
    }
}
