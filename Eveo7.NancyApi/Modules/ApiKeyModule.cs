using Eveo7.Models.Account;
using Eveo7.Models.ServiceInterfaces;
using Nancy;
using Nancy.Responses;
using Nancy.Security;

namespace Eveo7.Api.Modules
{
    public class ApiKeyModule : NancyModule
    {
        public ApiKeyModule(IApiKeyService apiKeyService) : base("/apiKey")
        {
            this.RequiresAuthentication();

            
            //Add Eve Online api key to Eveo7 account.
            Post["/addKey/{keyId:int}/{vCode}/{name}"] = parameters =>
            {
                var currentUser = (User)Context.CurrentUser;

                if (!apiKeyService.IsValidCharacterKey(parameters.KeyId, parameters.vCode))
                    return new TextResponse(HttpStatusCode.BadRequest, "Invalid Api Key.");

                if (!apiKeyService.CanCreateAccountApiKey(parameters.KeyId, parameters.vCode))
                    return new TextResponse(HttpStatusCode.BadRequest, "You can't use this api key");


                return apiKeyService.CreateAccountApiKey(parameters.KeyId, parameters.vCode, currentUser.Id, parameters.name);
            };

            //Returns AccountApiKey list for current user
            Get["/listKeys"] = parameters =>
            {
                var currentUser = (User)Context.CurrentUser;
                return apiKeyService.ListAccountApiKeys(currentUser.Id);
            };
        }
    }
}