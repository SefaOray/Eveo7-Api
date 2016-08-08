using Eveo7.Models.Account;

namespace Eveo7.Models.DataInterfaces
{
    public interface IAuthData
    {
        User RegisterUser(string email, string password, string salt, string token);
        User GetUserFromToken(string token);
    }
}
