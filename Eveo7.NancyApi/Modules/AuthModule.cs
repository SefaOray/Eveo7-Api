using System.Web.UI.WebControls;
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
            Post["/login/{email}/{password}"] = parameters =>
            {
                var user = authService.ValidateUser(parameters.email, parameters.password);

                return user == null ? ResponseHelper.ReturnBadRequestResponse("Invalid username/password") : user.Token;
            };

            Post["/register/{email}/{password}"] = parameters =>
            {
                if (authService.UserExistsWithEmail(parameters.email))
                    return ResponseHelper.ReturnBadRequestResponse("Email address already in use.");

                var user = (User)authService.Register(parameters.email, parameters.password);
                return user.Token;
            };
        }
    }
}