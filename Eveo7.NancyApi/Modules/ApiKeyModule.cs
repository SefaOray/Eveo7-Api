using Eveo7.Models.ServiceInterfaces;
using Eveo7.Services;
using Nancy;
using Nancy.Responses;

namespace Eveo7.Api.Modules
{
    public class ApiKeyModule : NancyModule
    {
        public ApiKeyModule(IApiKeyService apiKeyService) : base("/apiKey")
        {
            //Add Eve Online api key to Eveo7 account.
            Get["/addKey/{keyId:int}/{vCode}"] = parameters =>
            {
                if (!apiKeyService.IsValidCharacterKey(parameters.KeyId, parameters.vCode))
                    return new TextResponse(HttpStatusCode.BadRequest, "Invalid Api Key.");

                if (!apiKeyService.CanCreateAccountApiKey(parameters.KeyId, parameters.vCode))
                    return new TextResponse(HttpStatusCode.BadRequest, "You can't use this api key");


                return apiKeyService.CreateAccountApiKey(parameters.KeyId, parameters.vCode, "123");
            };
        }
    }
}