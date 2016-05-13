using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GL.CursoMvc.UI.Mvc.Startup))]
namespace GL.CursoMvc.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
