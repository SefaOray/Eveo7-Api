using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eveo7.Models.Account;
using Eveo7.Models.DataInterfaces;

namespace Eveo7.Data
{
    public class AccountListingData : IAccountListingData
    {
        public AccountCharacter AddCharacterToAccount(long characterId, int accouuntId, int accountKeyId)
        {
            var sql =
                $@"INSERT INTO Account_Characters(AccountId, KeyId, CharacterId) VALUES ({accouuntId},{accountKeyId}, {characterId})
                SELECT * FROM Account_Characters WHERE Id = SCOPE_IDENTITY()";

            return DataExecuter.QuerySingle<AccountCharacter>(sql);
        }
    }
}
