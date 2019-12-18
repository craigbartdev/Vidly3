using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly3.Controllers
{
    public class RentalsController : Controller
    {
        // Render the view where we will make post request to API
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Return()
        {
            return View();
        }
    }
}