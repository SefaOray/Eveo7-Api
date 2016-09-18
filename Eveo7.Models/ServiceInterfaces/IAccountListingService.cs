using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models.Account;
using Eveo7.Models.Account;
using static eZet.EveLib.EveXmlModule.Models.Account.CharacterList;

namespace Eveo7.Models.ServiceInterfaces
{
    public interface IAccountListingService
    {
        AccountCharacter AddCharacterToAccount(int accountKeyId, int accountId, long characterId);
        List<EveCharacter> GetCharactersInKey(int keyId, int userId);
        List<CharacterInfo> ListCharacters(int userId);

    }
}
