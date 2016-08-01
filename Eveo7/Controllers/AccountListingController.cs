using eZet.EveLib.EveXmlModule.Models.Account;
using System.Collections.Generic;
using System.Web.Http;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models.ServiceInterfaces;
using Microsoft.AspNet.Identity;

namespace Eveo7.Api.Controllers
{
    [Authorize]
    public class AccountListingController : ApiController
    {
        private readonly IAccountListingService _listingService;

        public AccountListingController(IAccountListingService accountListingService)
        {
            _listingService = accountListingService;
        }

        [HttpGet]
        public IEnumerable<CharacterList.CharacterInfo> GetCharacterListForKey(string vCode, long keyId)
        {
            var key = new ApiKey(keyId, vCode);
            return _listingService.GetCharacterInfos(key);
        }

        [HttpPost]
        public IHttpActionResult AddCharacterToAccount(ApiKey key, long characterId)
        {
            _listingService.AddCharacterToAccount(key,User.Identity.GetUserId(),characterId);

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
