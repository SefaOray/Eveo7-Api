using System;
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
        public AcountListingModule(IApiKeyService apiKeyService, IAccountListingService accountListingService) : base("/accountListing")
        {
            this.RequiresAuthentication();

            
            //Add Character from Eve Online api to user account
            Post["/addCharacter/{keyId:int}/{characterId:int}"] = parameters =>
            {
                var currentUser = (User)Context.CurrentUser;

                var userApiKeys = (IEnumerable<AccountApiKey>)apiKeyService.ListAccountApiKeys(currentUser.Id);

                var key = userApiKeys.FirstOrDefault(k => k.Id == parameters.keyId);

                if (key == null)
                    return ResponseHelper.ReturnBadRequestResponse("You can not add characters from this api key");

                var eveApiKey = new ApiKey(key.KeyId, key.VerificationCode);
                var characters = eveApiKey.GetCharacterList().Result.Characters;
                var character = characters.FirstOrDefault(c => c.CharacterId == parameters.characterId);

                if (character == null)
                    return
                        ResponseHelper.ReturnBadRequestResponse("Character is not exist in given api key information.");

                return accountListingService.AddCharacterToAccount(key.Id, parameters.accountId, parameters.characterId);
            };

            Get["/listCharacters"] = parameters =>
            {
                throw new NotImplementedException();
            };
        }
    }
}