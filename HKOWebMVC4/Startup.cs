using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HKOWebMVC4.Startup))]
namespace HKOWebMVC4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
