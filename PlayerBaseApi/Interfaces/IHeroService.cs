using PlayerBaseApi.Models;
using SharedLibrary.Models;

namespace PlayerBaseApi.Interfaces
{
    public interface IHeroService
    {
        Task<TDResponse<List<HeroDTO>>> GetHeroTypes(BaseRequest req, UserDto user);
        Task<TDResponse<List<PlayerHeroDTO>>> GetPlayerHeroes(BaseRequest req, UserDto user);
        Task<TDResponse<List<HeroLevelThresholdDTO>>> GetHeroesThresholds(BaseRequest req, UserDto user);
        Task<TDResponse<bool>> AddHeroExperience(BaseRequest<AddHeroExperienceRequest> req, UserDto user);
    }
}
