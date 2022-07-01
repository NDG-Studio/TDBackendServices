using IdentityApi.Models;
using SharedLibrary.Models;

namespace IdentityApi.Interfaces
{
    public interface IMailService    
    {
        bool SendMail(string mailAdress, string token);

    }
}