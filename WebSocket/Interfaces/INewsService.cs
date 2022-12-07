using SharedLibrary.Models;
using WebSocket.Models;

namespace WebSocket.Interfaces
{
    public interface INewsService
    {
        Task<TDResponse> SendImportantNews(ImportantNews req);
        Task<TDResponse> SendAnnouncment(ImportantNews req);
        Task<TDResponse> SendScoutNews(ScoutInfoDTO req);
        Task<TDResponse> SendAttackNews(AttackInfoDTO req);
    }
}
