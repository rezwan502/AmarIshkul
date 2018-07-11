using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AmarIshkul.Startup))]
namespace AmarIshkul
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
