using eZet.EveLib.EveXmlModule;
using Eveo7.Models.Account;

namespace Eveo7.Models.ServiceInterfaces
{
    public interface IApiKeyService
    {
        bool IsValidCharacterKey(long keyId, string vCode, bool throwIfInvalid = false);
        bool IsValidCharacterKey(ApiKey key, bool throwIfInvalid = false);
        bool KeyBelongsToAccount(int keyId, string userId);
        bool CanCreateAccountApiKey(int keyId, string vcode);
        AccountApiKey CreateAccountApiKey(int keyId, string vCode, string accountId);
    }
}
