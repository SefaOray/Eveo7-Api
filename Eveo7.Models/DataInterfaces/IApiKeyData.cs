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
    }
}
