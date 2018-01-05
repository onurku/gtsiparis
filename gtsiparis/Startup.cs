using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gtsiparis.Startup))]
namespace gtsiparis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
