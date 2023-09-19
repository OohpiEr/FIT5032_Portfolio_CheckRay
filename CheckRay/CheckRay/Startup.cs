using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckRay.Startup))]
namespace CheckRay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
