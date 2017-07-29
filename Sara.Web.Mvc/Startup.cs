using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sara.Web.Mvc.Startup))]
namespace Sara.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
