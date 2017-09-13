using System.Web.Http;
using Owin;

namespace Movie
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}