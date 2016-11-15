using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeopleQuest.Startup))]
namespace PeopleQuest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
