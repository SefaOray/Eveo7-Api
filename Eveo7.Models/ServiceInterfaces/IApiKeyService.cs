using System.Collections.Generic;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models.Account;

namespace Eveo7.Models.ServiceInterfaces
{
    public interface IApiKeyService
    {
        bool IsValidCharacterKey(long keyId, string vCode);
        bool IsValidCharacterKey(ApiKey key);
        bool KeyBelongsToAccount(int keyId, int userId);
        bool CanCreateAccountApiKey(int keyId, string vcode);
        AccountApiKey CreateAccountApiKey(int keyId, string vCode, int userId, string name);
        IEnumerable<AccountApiKey> ListAccountApiKeys(int accountId);
        AccountApiKey GetKey(int id);
        AccountApiKey GetKey(int id, int userId);
    }
}
