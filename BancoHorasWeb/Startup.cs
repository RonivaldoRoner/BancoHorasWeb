using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BancoHorasWeb.Startup))]
namespace BancoHorasWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
