using Eveo7.Models.Account;
using Eveo7.Models.ServiceInterfaces;
using Nancy;
using Nancy.Authentication.Stateless;
namespace Eveo7.Api.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(IAuthService authService) : base("/Auth")
        {
            Post["/login/{email:email}/{password}"] = parameters =>
            {
                var user = authService.ValidateUser(parameters.email, parameters.password);

                return user == null ? null : user.Token;
            };

            Post["/register/{email}/{password}"] = parameters =>
            {
                var user = (User)authService.Register(parameters.email, parameters.password);
                return user.Token;
            };
        }
    }
}