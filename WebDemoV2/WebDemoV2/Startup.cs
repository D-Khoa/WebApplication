using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDemoV2.Startup))]
namespace WebDemoV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
