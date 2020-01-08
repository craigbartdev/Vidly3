using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;

namespace Vidly3.Controllers
{
    public class DiscountController : Controller
    {
        private ApplicationDbContext _context;

        public DiscountController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Discount
        public ActionResult Index()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            return View(membershipTypes);
        }

        //Put to save the changes to the DiscountRate of MembershipTypes
        //must use a Post request which is what Html.BeginForm sends automatically
        [HttpPost]
        public ActionResult Save(List<MembershipType> membershipTypes)
        {
            var membershipTypesInDB = _context.MembershipTypes.ToList();

            if (!ModelState.IsValid)
            {
                return View("Index", membershipTypesInDB);
            }

            //get and set each membership type in the db to what user typed in the view
            foreach (MembershipType membershipType in membershipTypes)
            {
                var membershipTypeInDB = membershipTypesInDB.FirstOrDefault(m => m.Id == membershipType.Id);

                membershipTypeInDB.DiscountRate = membershipType.DiscountRate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}