using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json; //import these for json formatting
using Newtonsoft.Json.Serialization;

namespace Vidly3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //enable camelcase for javascript frontend
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            //stuff below was generated after adding a webapi controller
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
