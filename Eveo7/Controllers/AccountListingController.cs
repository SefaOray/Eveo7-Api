using eZet.EveLib.EveXmlModule.Models.Account;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models.ServiceInterfaces;
using Microsoft.AspNet.Identity;

namespace Eveo7.Api.Controllers
{
    public class AccountListingController : ApiController
    {
        private readonly IAccountListingService _listingService;
        private readonly IApiKeyService _apiKeyService;
        public AccountListingController(IAccountListingService accountListingService, IApiKeyService apiKeyService)
        {
            _listingService = accountListingService;
            _apiKeyService = apiKeyService;
        }

        [HttpGet]
        public IHttpActionResult GetCharacterListForKey(int keyId)
        {
            if (!_apiKeyService.KeyBelongsToAccount(keyId, User.Identity.GetUserId()))
                Request.CreateResponse(HttpStatusCode.Forbidden, "You are not authorized to list characters of this key");
            
            //return _listingService.GetCharacterInfos(key);
            return null;
        }

        [HttpPost]
        public IHttpActionResult AddCharacterToAccount(ApiKey key, long characterId)
        {
            _listingService.AddCharacterToAccount(key,"123",characterId);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddApiKeyToAccount(ApiKey key)
        {
            _listingService.AddApiKeyToAccount(key,User.Identity.GetUserId());

            return Ok();
        }
    }
}
