using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsTrainingFinalTask.Startup))]
namespace WebFormsTrainingFinalTask
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
