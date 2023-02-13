#pragma warning disable CS1591
using ZTD.Models;
using SharedLibrary.Models;

namespace ZTD.Interfaces
{
    public interface ITdService    
    {
        Task<TDResponse<ChapterInfoDTO>> GetChapterInfo(BaseRequest req, UserDto userDto);
        Task<TDResponse<List<LevelDTO>>> GetLevels(BaseRequest<List<int>> req, UserDto user);
        Task<TDResponse<List<TowerDTO>>> GetTowers(BaseRequest req, UserDto userDto);
        Task<TDResponse<List<EnemyDTO>>> GetEnemyList(BaseRequest req, UserDto userDto);

        Task<TDResponse<List<ItemDTO>>> GetItems(BaseRequest req, UserDto user);
        Task<TDResponse<List<ChestTypeDTO>>> GetChestTypes(BaseRequest req, UserDto user);
        Task<TDResponse<List<PlayerChestDTO>>> GetPlayerChests(BaseRequest req, UserDto user);
        Task<TDResponse<List<PlayerItemDTO>>> GetPlayerItems(BaseRequest req, UserDto user);

        Task<TDResponse<List<PlayerItemDTO>>> SetPlayerItems(BaseRequest<List<PlayerItemDTO>> req, UserDto user);
        Task<TDResponse<PlayerVariableDTO>> GetPlayerVariable(BaseRequest req, UserDto user);
        Task<TDResponse<PlayerVariableDTO>> SetPlayerVariable(BaseRequest<PlayerVariableDTO> req, UserDto user);
        Task<TDResponse<List<PlayerChestDTO>>> SetPlayerChests(BaseRequest<List<PlayerChestDTO>> req, UserDto user);
        Task<TDResponse<List<TableChangesDTO>>> GetSyncStatus(BaseRequest req, UserDto user);

        Task<TDResponse<List<ResearchNodeDTO>>> GetResearchNodes(BaseRequest req, UserDto user);
        Task<TDResponse<List<PlayerResearchNodeLevelDTO>>> GetPlayerResearchNodeLevels(BaseRequest req, UserDto user);
        Task<TDResponse<List<PlayerResearchNodeLevelDTO>>> SetPlayerResearchNodeLevels(
            BaseRequest<List<PlayerResearchNodeLevelDTO>> req, UserDto user);
        Task<TDResponse> AddProgressList(BaseRequest<List<ProgressDTO>> req, UserDto user);
    }
}