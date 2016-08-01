using System.Collections.Generic;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models.Account;
using Eveo7.Models;
using Eveo7.Models.DataInterfaces;
using Eveo7.Models.ServiceInterfaces;

namespace Eveo7.Services
{
    public class AccountListingService : IAccountListingService
    {
        private readonly IApiKeyService _apiKeyService;
        private readonly IApiKeyData _apiKeyData;
        private readonly IAccountListingData _accountListingData;
        public AccountListingService(IApiKeyService apiKeyService, IApiKeyData apiKeyData, IAccountListingData accountListingData)
        {
            _apiKeyService = apiKeyService;
            _apiKeyData = apiKeyData;
            _accountListingData = accountListingData;
        }

        public IEnumerable<CharacterList.CharacterInfo>  GetCharacterInfos(ApiKey key)
        {
            _apiKeyService.IsValidCharacterKey(key, true);

            return key.GetCharacterList().Result.Characters;
        }

        public void AddCharacterToAccount(ApiKey key, string accountId, long characterId)
        {
            _apiKeyService.IsValidCharacterKey(key, true);

            var accountApiKey = _apiKeyData.GetAccountApiKey(key, accountId);

            if(accountApiKey == null || accountApiKey.AccountId != accountId)
                throw new O7Exception("You are not authorized to add a character from this Api key.");

            _accountListingData.AddCharacterToAccount(characterId,accountId,accountApiKey);
        }

        public void AddApiKeyToAccount(ApiKey key, string accountId)
        {
            _apiKeyService.IsValidCharacterKey(key, true);

            var accountApiKey = _apiKeyData.GetAccountApiKey(key, accountId);

            if (accountApiKey != null && accountApiKey.AccountId != accountId)
                throw new O7Exception("You are not authorized to add a character from this Api key.");

            _accountListingData.AddApiKeyToAccount(key.KeyId,key.VCode,accountId);
        }
    }
}