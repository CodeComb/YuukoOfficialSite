using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(YuukoOfficialSite.Startup))]

namespace YuukoOfficialSite
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapYuuko();
        }
    }
}
