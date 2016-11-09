using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BundleTest.Startup))]
namespace BundleTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
