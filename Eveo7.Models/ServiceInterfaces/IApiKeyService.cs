using System.Collections.Generic;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models.Account;

namespace Eveo7.Models.ServiceInterfaces
{
    public interface IApiKeyService
    {
        bool IsValidCharacterKey(long keyId, string vCode);
        bool IsValidCharacterKey(ApiKey key);
        bool KeyBelongsToAccount(int keyId, string userId);
        bool CanCreateAccountApiKey(int keyId, string vcode);
        AccountApiKey CreateAccountApiKey(int keyId, string vCode, string accountId);
        IEnumerable<AccountApiKey> ListAccountApiKeys(string accountId);
    }
}
