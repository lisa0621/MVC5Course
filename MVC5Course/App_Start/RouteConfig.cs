using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5Course
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "PHPext",
            //    url: "{controller}-{action}-{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "MyHome",
            //    url: "MyHome/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    constraints: new
            //    {
            //        id = @"\d{3,}"
            //    }
            //);

            //routes.MapRoute(
            //    name: "Products",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new
            //    {
            //        controller = "Products",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    },
            //    constraints: new
            //    {
            //        controller = "{Products}|{Clients}|{OrderLine}",
            //        id = @"\d*"
            //    }
            //);

            routes.MapRoute(
                name: "Products",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Products",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                constraints: new
                {
                    controller = "Products",
                    id = @"\d*"
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                constraints: new
                {
                    controller = "(?!^Products$).*"
                }
            );
           
        }
    }
}
