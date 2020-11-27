using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BSPTestWebApp.Startup))]
namespace BSPTestWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
