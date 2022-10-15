using ProgressApi.Models;
using SharedLibrary.Models;

namespace ProgressApi.Interfaces
{
    public interface IProgressService    
    {
        Task<TDResponse> AddProgress(BaseRequest<ProgressDTO> req, UserDto userDto);
        Task<TDResponse<List<EnemyDTO>>> GetZombies(BaseRequest req);
        Task<TDResponse<List<TowerDTO>>> GetTowers(BaseRequest req);
        Task<TDResponse<List<StageDTO>>> GetStages(BaseRequest req);
        Task<TDResponse<List<StageStatusDTO>>> GetUserStageStatus(BaseRequest req, UserDto UserDto);
        Task<TDResponse<UserTDInfoDTO>> GetNextWave(BaseRequest req, UserDto user);
    }
}