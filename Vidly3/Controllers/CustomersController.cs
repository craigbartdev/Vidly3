using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;

namespace Vidly3.Controllers
{
    public class CustomersController : Controller
    {
        //for using db data in this controller
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET Customers 
        public ViewResult Index()
        {
            //get all customers
            //use toList to be query over customers immediately instead of in foreach statement of view
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        //GET Customers/Details/id
        public ActionResult Details(int id)
        {
            //get single customer by id
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        ////mock data
        ////used to call GetCustomers() in methods instead of _context
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer {Id = 1, Name = "John Smith"},
        //        new Customer {Id = 2, Name = "Mary Williams"}
        //    };
        //}
    }
}