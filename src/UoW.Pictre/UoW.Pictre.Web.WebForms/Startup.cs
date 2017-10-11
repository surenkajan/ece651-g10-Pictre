using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UoW.Pictre.Web.WebForms.Startup))]
namespace UoW.Pictre.Web.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
