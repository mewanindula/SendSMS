using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestSMS.Startup))]
namespace TestSMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
