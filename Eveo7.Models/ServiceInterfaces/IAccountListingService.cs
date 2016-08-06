using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models.Account;
using Eveo7.Models.Account;

namespace Eveo7.Models.ServiceInterfaces
{
    public interface IAccountListingService
    {
        AccountCharacter AddCharacterToAccount(int accountKeyId, int accountId, long characterId);

    }
}
