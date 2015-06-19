using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakeYourPartyServer.Startup))]
namespace MakeYourPartyServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
