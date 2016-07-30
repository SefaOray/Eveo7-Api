using eZet.EveLib.EveXmlModule;
using Eveo7.Models.ServiceInterfaces;

namespace Eveo7.Services
{
    public class ApiKeyService : IApiKeyService
    {
        public bool IsValidCharacterKey(long keyId, string vCode)
        {
            var key = new ApiKey(keyId, vCode);

            if (!key.IsValidKey() || key.KeyType == ApiKeyType.Account)
                return false;

            return true;
        }
    }
}
