﻿using System.Collections.Generic;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models.Account;
using Eveo7.Models.Account;
using Eveo7.Models.DataInterfaces;
using Eveo7.Models.ServiceInterfaces;
using System.Linq;
using static eZet.EveLib.EveXmlModule.Models.Account.CharacterList;
using System.Threading.Tasks;

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

        public List<EveCharacter> GetCharactersInKey(int keyId, int userId)
        {
            var key = _apiKeyService.GetKey(keyId);

            if (key == null)
                return null;

            var apiKey = new ApiKey(key.KeyId, key.VerificationCode);

            if (!apiKey.IsValidKey())
                return null;

            var characters = apiKey.GetCharacterList().Result.Characters;
            var result = new List<EveCharacter>();
            foreach (var characterInfo in characters)
            {
                var character = new EveCharacter();
                character.Name = characterInfo.CharacterName;
                character.Id = characterInfo.CharacterId;
                character.IsAdded = key.Characters.Count(x => x.CharacterId == characterInfo.CharacterId) == 1;
                result.Add(character);
            }

            return result;
        }

        public List<CharacterInfo> ListCharacters(int userId)
        {
            var keys = _apiKeyData.LisAccountApiKeys(userId);
            var characters = new List<CharacterInfo>();

            var tasks = keys.ToList().Select((x) => {
                var key = new ApiKey(x.KeyId, x.VerificationCode);
                return key.GetCharacterListAsync();
            });

            var results = Task.WhenAll(tasks);

            foreach (var item in results.Result)
            {
                characters.AddRange(item.Result.Characters);
            }

            return characters;
        }
    }
}