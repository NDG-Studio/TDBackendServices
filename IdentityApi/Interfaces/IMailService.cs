using IdentityApi.Models;
using SharedLibrary.Models;

namespace IdentityApi.Interfaces
{
    public interface IMailService    
    {
        Task<bool> SendMailAsync(string mailAdress, string token);

    }
}