using ZTD.Models;
using SharedLibrary.Models;

namespace ZTD.Interfaces
{
    public interface IDialogService
    {
        Task<TDResponse<List<DialogSceneDTO>>> GetDialogScenes(BaseRequest req, UserDto user);
    }
}