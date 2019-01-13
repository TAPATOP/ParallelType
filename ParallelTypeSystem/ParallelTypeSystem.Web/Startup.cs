using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ParallelTypeSystem.Web.Startup))]

namespace ParallelTypeSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
