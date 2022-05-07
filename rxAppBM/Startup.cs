using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rxApp.Startup))]
namespace rxApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
