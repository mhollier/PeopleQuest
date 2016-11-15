using System.Data.Entity.Migrations;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PeopleQuest.Migrations;

namespace PeopleQuest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Apply migrations to the PeopleQuest database.
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
