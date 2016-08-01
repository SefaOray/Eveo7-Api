using System;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models;
using Eveo7.Models.ServiceInterfaces;

namespace Eveo7.Services
{
    public class ApiKeyService : IApiKeyService
    {
        public bool IsValidCharacterKey(long keyId, string vCode, bool throwIfInvalid = false)
        {
            var key = new ApiKey(keyId, vCode);

            var valid = key.IsValidKey() && key.KeyType != ApiKeyType.Account;
            
            if(!valid && throwIfInvalid)
                throw new O7Exception("Not valid account/character key.");

            return valid;
        }

        public bool IsValidCharacterKey(ApiKey key, bool throwIfInvalid = false)
        {
            var valid = key.IsValidKey() && key.KeyType != ApiKeyType.Account;

            if (!valid && throwIfInvalid)
                throw new O7Exception("Not valid account/character key.");

            return valid;
        }
    }
}
