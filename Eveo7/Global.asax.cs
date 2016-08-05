using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Eveo7.Api;
using Eveo7.Data;
using Eveo7.Models.DataInterfaces;
using Eveo7.Models.ServiceInterfaces;
using Eveo7.Services;

namespace Eveo7.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes); No need for mvc routes
            //BundleConfig.RegisterBundles(BundleTable.Bundles);


            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<AccountListingService>().As<IAccountListingService>().InstancePerLifetimeScope();
            builder.RegisterType<ApiKeyService>().As<IApiKeyService>().InstancePerLifetimeScope();
            builder.RegisterType<AccountListingData>().As<IAccountListingData>().InstancePerLifetimeScope();
            builder.RegisterType<ApiKeyData>().As<IApiKeyData>().InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
