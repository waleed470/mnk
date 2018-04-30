using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mnk.Startup))]
namespace Mnk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
