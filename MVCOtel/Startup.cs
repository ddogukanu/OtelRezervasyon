using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCOtel.Startup))]
namespace MVCOtel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
