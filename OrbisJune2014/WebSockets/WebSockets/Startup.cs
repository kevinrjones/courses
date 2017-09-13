using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSockets.Startup))]
namespace WebSockets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
