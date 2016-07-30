using eZet.EveLib.EveXmlModule.Models.Account;
using System.Collections.Generic;
using System.Web.Http;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models.ServiceInterfaces;

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
    }
}
