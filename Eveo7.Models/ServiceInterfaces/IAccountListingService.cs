using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models.Account;

namespace Eveo7.Models.ServiceInterfaces
{
    public interface IAccountListingService
    {
        IEnumerable<CharacterList.CharacterInfo> GetCharacterInfos(ApiKey key);
        void AddCharacterToAccount(ApiKey key, string accountId, long characterId);

    }
}
