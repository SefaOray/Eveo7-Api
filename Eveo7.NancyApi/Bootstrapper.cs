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
                var token = nancyContext.Request.Headers.Authorization;

                if (string.IsNullOrWhiteSpace(token))
                    return null;

                var validator = container.Resolve<IAuthService>();

                return validator.GetUserFromToken(token);
            });

            StatelessAuthentication.Enable(pipelines,config);

            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                                .WithHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS")
                                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type, Authorization");

            });
        }
    }
}