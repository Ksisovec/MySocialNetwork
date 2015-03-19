using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySocialNetwork2.Startup))]
namespace MySocialNetwork2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
