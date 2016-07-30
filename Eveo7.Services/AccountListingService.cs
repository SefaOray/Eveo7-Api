using System;
using System.Collections.Generic;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models.Account;
using Eveo7.Models;
using Eveo7.Models.ServiceInterfaces;

namespace Eveo7.Services
{
    public class AccountListingService : IAccountListingService
    {
        public IEnumerable<CharacterList.CharacterInfo>  GetCharacterInfos(ApiKey key)
        {
            if (!key.IsValidKey())
                throw new EveApiException("Api key is not valid.");

            if (key.KeyType == ApiKeyType.Corporation)
                throw new EveApiException("Api key is not account/character.");

            return key.GetCharacterList().Result.Characters;
        }
    }
}
