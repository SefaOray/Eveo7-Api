using System;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models.Account;
using Eveo7.Models.DataInterfaces;

namespace Eveo7.Data
{
    public class ApiKeyData : IApiKeyData
    {
        public AccountApiKey GetAccountApiKey(ApiKey key, string accountId)
        {
            var sql =
                $"SELECT * FROM Account_ApiKeys WITH (NOLOCK) WHERE KeyId = {key.KeyId} AND VerificationCode = '{key.VCode}'";

            var dbResult = DataExecuter.Querysingle<AccountApiKey>(sql);

            return dbResult;
        }
    }
}