using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyecto_Ato.Startup))]
namespace Proyecto_Ato
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
