using Eveo7.Models.Account;
using Eveo7.Models.DataInterfaces;

namespace Eveo7.Data
{
    public class AuthData : IAuthData
    {
        public User RegisterUser(string email, string password, string salt, string token)
        {
            var sql =
                $@"INSERT INTO Account_Users(Email, Password, Token, Salt) VALUES('{email}', '{password}', '{token}', '{salt}' 
                SELECT Id, Email, Token FROM Account_Users WHERE Id = SCOPE_IDENTITY()";

            return DataExecuter.QuerySingle<User>(sql);
        }

        public User GetUserFromToken(string token)
        {
            var sql = $@"SELECT Id, Email from Account_Users WITH (NOLOCK) WHERE Token = '{token}'";

            return DataExecuter.QuerySingle<User>(sql);
        }
    }
}