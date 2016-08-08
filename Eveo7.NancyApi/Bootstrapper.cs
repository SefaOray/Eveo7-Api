using Eveo7.Models.ServiceInterfaces;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Eveo7.Api
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            var config = new StatelessAuthenticationConfiguration(nancyContext =>
            {
                var token = nancyContext.Request.Query.token;

                if (token == null)
                    return null;

                var validator = container.Resolve<IAuthService>();

                return validator.GetUserFromToken(token);
            });

            StatelessAuthentication.Enable(pipelines,config);
        }
    }
}