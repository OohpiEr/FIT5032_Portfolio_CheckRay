using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckRayApp.Startup))]
namespace CheckRayApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
