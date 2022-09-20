using PlayerBaseApi.Models;
using SharedLibrary.Models;

namespace PlayerBaseApi.Interfaces
{
    public interface IHeroService
    {
        Task<TDResponse<List<HeroDTO>>> GetHeroTypes(BaseRequest req, UserDto user);
        Task<TDResponse<PlayerHeroDTO>> GetPlayersHeroById(BaseRequest<int> req, UserDto user);
        Task<TDResponse<bool>> AddHeroExperience(BaseRequest<AddHeroExperienceRequest> req, UserDto user);
        Task<TDResponse<List<TalentTreeDTO>>> GetHeroTalentTreeByHeroId(BaseRequest<int> req, UserDto user);
        Task<TDResponse> AddHeroTalentNodeByNodeId(BaseRequest<int> req, UserDto user);
        Task<TDResponse<List<HeroSkillDTO>>> GetHeroSkillsByHeroId(BaseRequest<int> req, UserDto user);
        Task<TDResponse> UpgradeHeroSkillBySkillId(BaseRequest<int> req, UserDto user);
    }
}
