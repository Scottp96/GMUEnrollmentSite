using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GMUEnrollmentSite.Startup))]
namespace GMUEnrollmentSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
