using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(guestHouse.Startup))]
namespace guestHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
