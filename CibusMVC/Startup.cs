using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CibusMVC.Startup))]
namespace CibusMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
