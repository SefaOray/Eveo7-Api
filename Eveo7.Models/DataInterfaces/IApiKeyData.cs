using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models.Account;

namespace Eveo7.Models.DataInterfaces
{
    public interface IApiKeyData
    {
        AccountApiKey GetAccountApiKey(ApiKey key, string accountId);
        AccountApiKey GetAccountApiKey(int keyId);
        AccountApiKey GetAccountApiKey(int keyId, string vCode);
        AccountApiKey CreateAccountApiKey(int keyId, string vCode, string userId);
    }
}
