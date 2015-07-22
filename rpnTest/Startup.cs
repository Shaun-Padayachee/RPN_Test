using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rpnTest.Startup))]
namespace rpnTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
