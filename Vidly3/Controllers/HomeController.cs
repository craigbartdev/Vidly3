using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly3.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //disable caching for action with [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]

        //add output cache for datatime in Index view
        //time updates every 50 seconds
        //Set location to server because it is not specific to a user
        //can varybyparam to store different versions of page in cache depending on parameters
        //do not prematurely optimize with VaryByParam
        [OutputCache(Duration = 50, Location = OutputCacheLocation.Server)] //, VaryByParam = "genre")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}