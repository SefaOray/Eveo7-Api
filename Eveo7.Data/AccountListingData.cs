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
        public AccountCharacter AddCharacterToAccount(long characterId, int accountId, int accountKeyId)
        {
            var sql =
                $@"INSERT INTO Account_Characters(AccountId, KeyId, CharacterId) VALUES (@accountId,@accountKeyId, @characterId)
                SELECT * FROM Account_Characters WHERE Id = SCOPE_IDENTITY()";

            var param = new
            {
                accountId = accountId,
                accountKeyId = accountKeyId,
                characterId = characterId
            };

            return DataExecuter.QuerySingle<AccountCharacter>(sql, param);
        }
    }
}
