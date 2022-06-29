using ProgressApi.Models;
using SharedLibrary.Models;

namespace ProgressApi.Interfaces
{
    public interface IProgressService    
    {
        Task<TDResponse> AddProgress(ProgressDto progressDto,string? ip,UserDto userDto);
    }
}