using System;
using Eveo7.Models.Account;
using Eveo7.Models.DataInterfaces;
using Eveo7.Models.ServiceInterfaces;

namespace Eveo7.Services
{
    public class AuthService : IAuthService
    {
        private readonly ISecurityService _securityService;
        private readonly IAuthData _authData;
        public AuthService(ISecurityService securityService, IAuthData authData)
        {
            _securityService = securityService;
            _authData = authData;
        }
        private readonly object _thisLock = new object();
        public User Register(string email, string password)
        {
            var salt = _securityService.CreateSalt(32);
            var hashedPass = _securityService.Encrypt(System.Text.Encoding.UTF8.GetBytes(password), salt);
            var token = "";
            lock (_thisLock)
            {
                 token = Guid.NewGuid().ToString();
            }
            
            return _authData.RegisterUser(email, System.Text.Encoding.UTF8.GetString(hashedPass), System.Text.Encoding.UTF8.GetString(salt), token);
        }

        public User GetUserFromToken(string token)
        {
            return  _authData.GetUserFromToken(token);
        }

        public User ValidateUser(string email, string password)
        {
            var user = _authData.GetUserFromUsername(email);

            if (user == null)
                return null;

            var decryptedPass = _securityService.Encrypt(System.Text.Encoding.UTF8.GetBytes(password), System.Text.Encoding.UTF8.GetBytes(user.Salt));

            if (_securityService.CompareByteArrays(System.Text.Encoding.UTF8.GetBytes(user.Password),decryptedPass))
                return user;

            return null; 
        }

        public bool UserExistsWithEmail(string email)
        {
            var user = _authData.GetUserFromUsername(email);

            return user != null;
        }
    }
}
