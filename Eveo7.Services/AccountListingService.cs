using System.Collections.Generic;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models.Account;
using Eveo7.Models;
using Eveo7.Models.Account;
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

        public AccountCharacter AddCharacterToAccount(int accountKeyId, int accountId, long characterId)
        {
            return _accountListingData.AddCharacterToAccount(characterId,accountId, accountKeyId);
        }
    }
}