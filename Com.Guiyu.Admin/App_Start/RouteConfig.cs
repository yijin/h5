using Com.Guiyu.Admin.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Com.Guiyu.Admin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

           // routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          //  routes.Add(new Route("web/{page}", new WebFormsRouteHandler()));
            // 其中URL中{folder}和{page}所占的部分会被在WebFormsRouteHandler中当做参数使用
            //routes.Add(new Route("web/{folder}/{page}", new WebFormsFolderRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}