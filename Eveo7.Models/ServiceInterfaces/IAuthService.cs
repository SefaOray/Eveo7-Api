using Eveo7.Models.Account;

namespace Eveo7.Models.ServiceInterfaces
{
    public interface IAuthService
    {
        User GetUserFromToken(string token);
    }
}
