using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); //allow attribute routing in controllers

            ////custom route below
            //routes.MapRoute(
            //    "MoviesByReleaseDate", //name
            //    "movies/released/{year}/{month}", //url
            //    new { controller = "Movies", action = "ByReleaseDate"}, //defaults. must be same names as controller and action
            //    new { year = @"\d{4}", month = @"\d{2}" }); //constraints. can also do "\\d, but @ makes up for first \
            //    //would set year = {2015|2016} if we only wanted those exact years. | is an or

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
