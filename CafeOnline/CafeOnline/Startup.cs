using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CafeOnline.Startup))]
namespace CafeOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
