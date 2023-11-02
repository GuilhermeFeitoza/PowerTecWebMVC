using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PowerTecWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Colaborador",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "AreaColaborador", action = "IndexColaborador", id = UrlParameter.Optional }
         );
            routes.MapRoute(
    name: "Gerente",
    url: "{controller}/{action}/{id}",
    defaults: new { controller = "AreaGerente", action = "Index", id = UrlParameter.Optional }
);
        }
    }
}
