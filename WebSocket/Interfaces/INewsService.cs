using SharedLibrary.Models;
using WebSocket.Models;

namespace WebSocket.Interfaces
{
    public interface INewsService
    {
        Task<TDResponse> SendImportantNews(ImportantNews req);
        Task<TDResponse> SendAnnouncment(ImportantNews req);
    }
}
