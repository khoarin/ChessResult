using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nexcel.ChessResult.Demo.Startup))]
namespace Nexcel.ChessResult.Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
