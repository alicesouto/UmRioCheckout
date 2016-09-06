using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UmRioCheckout.Startup))]
namespace UmRioCheckout
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
