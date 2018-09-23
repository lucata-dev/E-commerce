using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWebApplication.Startup))]
namespace MVCWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            new Ecommerce.Business.Startup().ConfigureAuth(app);
        }
    }
}
