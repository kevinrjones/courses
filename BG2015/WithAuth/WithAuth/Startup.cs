using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WithAuth.Startup))]
namespace WithAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
