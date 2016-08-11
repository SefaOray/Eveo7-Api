using System;
using System.Collections.Generic;
using Nancy.Security;

namespace Eveo7.Models.Account
{
    public class User : IUserIdentity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public string Email
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public string Token { get; set; }
        public User()
        {
            
        }

        public User(IEnumerable<string> claims, string userName)
        {
            Claims = claims;
            UserName = userName;
        }
    }
}
