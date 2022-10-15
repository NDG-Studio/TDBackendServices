using ProgressApi.Models;
using SharedLibrary.Models;

namespace ProgressApi.Interfaces
{
    public interface IProgressService    
    {
        Task<TDResponse> AddProgress(BaseRequest<ProgressDto> req, UserDto userDto);
        Task<TDResponse<List<EnemyDto>>> GetZombies(BaseRequest req);
        Task<TDResponse<List<TowerDto>>> GetTowers(BaseRequest req);
        Task<TDResponse<List<StageDto>>> GetStages(BaseRequest req);
        Task<TDResponse<List<StageStatusDto>>> GetUserStageStatus(BaseRequest req, UserDto userDto);
    }
}