using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCControl.Startup))]
namespace PCControl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
