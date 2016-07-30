using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Eveo7.Startup))]

namespace Eveo7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            throw new NotImplementedException();
        }
    }
}
