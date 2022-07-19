using ProgressApi.Models;
using SharedLibrary.Models;

namespace ProgressApi.Interfaces
{
    public interface IProgressService    
    {
        Task<TDResponse> AddProgress(BaseRequest<ProgressDto> req, UserDto userDto);
    }
}