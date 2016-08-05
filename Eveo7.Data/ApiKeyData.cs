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

        public AccountApiKey GetAccountApiKey(int keyId)
        {
            var sql = $"SELECT * FROM Account_ApiKeys WITH (NOLOCK) WHERE Id = {keyId}";

            var dbResult = DataExecuter.Querysingle<AccountApiKey>(sql);

            return dbResult;
        }

        public AccountApiKey GetAccountApiKey(int keyId, string vCode)
        {
            var sql = $"SELECT * FROM Account_ApiKeys WITH (NOLOCK) WHERE KeyId = {keyId} AND VerificationCode = '{vCode}'";

            var dbResult = DataExecuter.Querysingle<AccountApiKey>(sql);

            return dbResult;
        }

        public AccountApiKey CreateAccountApiKey(int keyId, string vCode, string userId)
        {
            var sql = $@"INSERT INTO Account_ApiKeys(KeyId, VerificationCode, UserId) VALUES ({keyId}, '{vCode}', '{userId}')
                        SELECT * FROM Account_ApiKeys WHERE Id = SCOPE_IDENTITY()";

            var dbResult = DataExecuter.Querysingle<AccountApiKey>(sql);

            return dbResult;
        }
    }
}