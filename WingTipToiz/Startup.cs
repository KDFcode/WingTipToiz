using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WingTipToiz.Startup))]
namespace WingTipToiz
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
