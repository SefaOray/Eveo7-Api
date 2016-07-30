using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eveo7.Models.ServiceInterfaces;

namespace Eveo7.Api.Controllers
{
    [Authorize]
    public class ApiKeyController : ApiController
    {
        private readonly IApiKeyService _apiKeyService;
        public ApiKeyController(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        [HttpGet]
        public bool IsKeyValid(string vCode, long key)
        {
            return _apiKeyService.IsValidCharacterKey(key, vCode);
        }
    }
}
