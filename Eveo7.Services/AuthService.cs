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

        public User Register(string email, string password)
        {
            var salt = _securityService.GenerateSalt();
            var hashedPass = _securityService.Encrypt(password, salt);
            var token = new Guid().ToString();
            return _authData.RegisterUser(email, hashedPass, salt, token);
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

            var hashedPass = _securityService.Decrypt(password, user.Salt);

            if (hashedPass == user.Password)
                return user;

            return null;
        }
    }
}
