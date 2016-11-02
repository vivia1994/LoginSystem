using LoginEmpty.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LoginEmpty
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //数据库初始化器----2:DropCreateDatabaseAlways    1.DropCreateDatabaseIfModelChanges
            //Database.SetInitializer(
            //    new DropCreateDatabaseIfModelChanges<DatabaseContext>());
            Database.SetInitializer(new DataBaseDbInitializer());       //注册初始器

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
