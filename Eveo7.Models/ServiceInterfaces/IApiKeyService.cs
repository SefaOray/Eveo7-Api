using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;

namespace Eveo7.Models.ServiceInterfaces
{
    public interface IApiKeyService
    {
        bool IsValidCharacterKey(long keyId, string vCode, bool throwIfInvalid = false);
        bool IsValidCharacterKey(ApiKey key, bool throwIfInvalid = false);
    }
}
