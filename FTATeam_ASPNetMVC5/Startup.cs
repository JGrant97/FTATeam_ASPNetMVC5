using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FTATeam_ASPNetMVC5.Startup))]
namespace FTATeam_ASPNetMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
