#pragma warning disable CS1591
using ZTD.Models;
using SharedLibrary.Models;

namespace ZTD.Interfaces
{
    public interface ITdService    
    {
        Task<TDResponse<ChapterInfoDTO>> GetChapterInfo(BaseRequest req, UserDto userDto);
        Task<TDResponse<List<LevelDTO>>> GetLevels(BaseRequest<List<int>> req, UserDto userDto);
        Task<TDResponse<List<TowerDTO>>> GetTowers(BaseRequest req, UserDto userDto);
        Task<TDResponse<List<TableChangesDTO>>> GetSyncStatus(BaseRequest req, UserDto user);
        Task<TDResponse> AddProgressList(BaseRequest<List<ProgressDTO>> req, UserDto user);
    }
}