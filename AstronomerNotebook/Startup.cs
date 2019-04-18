using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AstronomerNotebook.Startup))]
namespace AstronomerNotebook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
