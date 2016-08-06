using System.Collections.Generic;
using Nancy.Security;

namespace Eveo7.Models.Account
{
    public class User : IUserIdentity
    {
        public int Id { get; set; }
        public string UserName { get; }
        public IEnumerable<string> Claims { get; }

        public string Email { get; set; }
        public string Password { get; set; }

        public User(IEnumerable<string> claims, string userName)
        {
            Claims = claims;
            UserName = userName;
        }

        public User()
        {
            
        }
    }
}
