using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CricketWeb.Startup))]
namespace CricketWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
