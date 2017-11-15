using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iMarket.MVC.Startup))]
namespace iMarket.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
