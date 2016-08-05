using System.Collections.Generic;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models;
using Eveo7.Models.Account;
using Eveo7.Models.DataInterfaces;
using Eveo7.Models.ServiceInterfaces;

namespace Eveo7.Services
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IApiKeyData _keyData;
        public ApiKeyService(IApiKeyData apiKeyData)
        {
            _keyData = apiKeyData;
        }

        public bool IsValidCharacterKey(long keyId, string vCode)
        {
            return IsValidCharacterKey(new ApiKey(keyId,vCode));
        }

        public bool IsValidCharacterKey(ApiKey key)
        {
            var valid = key.IsValidKey() && key.KeyType != ApiKeyType.Account;


            return valid;
        }

        public bool KeyBelongsToAccount(int keyId, string userId)
        {
            var apiKey = _keyData.GetAccountApiKey(keyId);

            if (apiKey != null || apiKey.AccountId != userId)
                return false;

            return true;
        }

        public AccountApiKey GetAccountApiKey(int keyId, string vCode)
        {
            return _keyData.GetAccountApiKey(keyId, vCode);
        }

        public bool CanCreateAccountApiKey(int keyId, string vcode)
        {
            var key = GetAccountApiKey(keyId, vcode);

            return key == null;
        }

        public AccountApiKey CreateAccountApiKey(int keyId, string vCode, string accountId)
        {
            return _keyData.CreateAccountApiKey(keyId, vCode, accountId);
        }

        public IEnumerable<AccountApiKey> ListAccountApiKeys(string accountId)
        {
            return _keyData.LisAccountApiKeys(accountId);
        }
    }
}
