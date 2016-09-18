using System;
using System.Collections.Generic;
using eZet.EveLib.EveXmlModule;
using Eveo7.Models.Account;
using Eveo7.Models.DataInterfaces;

namespace Eveo7.Data
{
    public class ApiKeyData : IApiKeyData
    {
        public AccountApiKey GetAccountApiKey(ApiKey key, int userId)
        {
            var sql =
                $"SELECT * FROM Account_ApiKeys WITH (NOLOCK) WHERE KeyId = @keyId AND VerificationCode = @vCode";

            var param = new { keyId = key.KeyId, vCode = key.VCode };
            var dbResult = DataExecuter.QuerySingle<AccountApiKey>(sql, param);

            return dbResult;
        }

        public AccountApiKey GetAccountApiKey(int keyId)
        {
            var sql = $"SELECT * FROM Account_ApiKeys WITH (NOLOCK) WHERE Id = @keyId";

            var dbResult = DataExecuter.QuerySingle<AccountApiKey>(sql, new { keyId = keyId });

            return dbResult;
        }

        public AccountApiKey GetAccountApiKey(int keyId, int userId)
        {
            var sql =
                $"SELECT * FROM Account_ApiKeys WITH (NOLOCK) WHERE Id = @keyId AND UserId = @userId";

            var param = new { keyId = keyId, userId = userId };
            var dbResult = DataExecuter.QuerySingle<AccountApiKey>(sql, param);

            return dbResult;
        }

        public AccountApiKey GetAccountApiKey(int keyId, string vCode)
        {
            var sql = $"SELECT * FROM Account_ApiKeys WITH (NOLOCK) WHERE KeyId = @keyId AND VerificationCode = @vCode";

            var param = new
            {
                keyId = keyId,
                vCode = vCode
            };

            var dbResult = DataExecuter.QuerySingle<AccountApiKey>(sql, param);

            return dbResult;
        }

        public AccountApiKey CreateAccountApiKey(int keyId, string vCode, int userId, string name)
        {
            var sql = $@"INSERT INTO Account_ApiKeys(KeyId, VerificationCode, UserId, Name) VALUES (@keyId, @vCode, @userId, @name)
                        SELECT * FROM Account_ApiKeys WHERE Id = SCOPE_IDENTITY()";

            var param = new
            {
                keyId = keyId,
                vCode = vCode,
                userId = userId,
                name = name
            };

            var dbResult = DataExecuter.QuerySingle<AccountApiKey>(sql, param);

            return dbResult;
        }

        public IEnumerable<AccountApiKey> LisAccountApiKeys(int userId)
        {
            var sql = $@"SELECT * FROM Account_ApiKeys WITH (NOLOCK) WHERE UserId = @userId";

            var dbResult = DataExecuter.QueryMany<AccountApiKey>(sql, new { userId = userId });

            return dbResult;
        }


    }
}