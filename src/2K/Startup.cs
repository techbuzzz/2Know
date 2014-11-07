using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2K.Startup))]
namespace _2K
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
