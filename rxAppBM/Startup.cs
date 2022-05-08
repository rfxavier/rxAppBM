using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rxAppBM.Startup))]
namespace rxAppBM
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
