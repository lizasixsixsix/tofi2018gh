using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tofi2018.Startup))]
namespace tofi2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
