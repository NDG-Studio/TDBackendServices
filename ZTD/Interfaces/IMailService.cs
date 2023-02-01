using ZTD.Models;
using SharedLibrary.Models;

namespace ZTD.Interfaces
{
    public interface IMailService    
    {
        Task<bool> SendMailAsync(string mailAdress, string token);

    }
}