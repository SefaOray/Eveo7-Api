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
        public void AddCharacterToAccount(long characterId, string accountId, AccountApiKey key)
        {
            var sql =
                $"INSERT INTO Account_Characters(AccountId, KeyId, CharacterId) VALUES ('{accountId}',{key.Id}, {characterId})";

            DataExecuter.Execute(sql);
        }
    }
}
