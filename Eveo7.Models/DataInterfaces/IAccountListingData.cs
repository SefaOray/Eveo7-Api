using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eveo7.Models.Account;

namespace Eveo7.Models.DataInterfaces
{
    public interface IAccountListingData
    {
        AccountCharacter AddCharacterToAccount(long characterId, int accouuntId, int accountKeyId);
    }
}
