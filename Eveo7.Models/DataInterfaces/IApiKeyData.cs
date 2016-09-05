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
        AccountApiKey GetAccountApiKey(ApiKey key, int userId);
        AccountApiKey GetAccountApiKey(int keyId);
        AccountApiKey GetAccountApiKey(int keyId, int userId);
        AccountApiKey GetAccountApiKey(int keyId, string vCode);
        AccountApiKey CreateAccountApiKey(int keyId, string vCode, int userId, string name);
        IEnumerable<AccountApiKey> LisAccountApiKeys(int userId);
    }
}
