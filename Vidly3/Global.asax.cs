using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Vidly3.App_Start; //for MappingProfile

namespace Vidly3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //for automapper
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            //use web api
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //below were generated on creating project
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
