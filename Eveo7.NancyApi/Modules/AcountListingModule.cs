using Eveo7.Models.ServiceInterfaces;
using Nancy;
using Nancy.Security;
using System.Collections.Generic;
using System.Linq;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models.Account;
using Nancy.Responses;

namespace Eveo7.Api.Modules
{
    public class AcountListingModule : NancyModule
    {
        public AcountListingModule(IApiKeyService apiKeyService, IAccountListingService accountListingService)
        {
            this.RequiresAuthentication();

            //Add Character from Eve Online api to user account
            Post["/addCharacter/{accountId}/{keyId:int}/{characterId:int}"] = parameters =>
            {
                var userApiKeys = (IEnumerable<AccountApiKey>)apiKeyService.ListAccountApiKeys(parameters.accountId);

                var key = userApiKeys.FirstOrDefault(k => k.Id == parameters.keyId);

                if (key == null)
                    return new TextResponse(HttpStatusCode.BadRequest, "You can not add a character from this Api Key");

                var eveApiKey = new ApiKey(key.KeyId, key.VCode);
                var characters = eveApiKey.GetCharacterList().Result.Characters;
                var character = characters.FirstOrDefault(c => c.CharacterId == parameters.characterId);

                if(character == null)
                    return  new TextResponse(HttpStatusCode.BadRequest, "Character is not exist in given api key information.");

                return accountListingService.AddCharacterToAccount(key.Id, parameters.accountId, parameters.characterId);
            };

            Get["/listCharacters/{accountId:int}"] = parameters =>
            {

                return null;
            };
        }
    }
}