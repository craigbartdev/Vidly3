using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;

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

        public ActionResult New()
        {
            //get from dab
            var membershipTypes = _context.MembershipTypes.ToList();
            //bind membershiptypes data to viewmodel
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            //pass to the View
            return View("CustomerForm", viewModel);
        }

        //update Customers/Edit/id
        public ActionResult Edit(int id)
        {
            //get customer from db
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            //change name from NewCustomerViewModel to CustomerFormViewModel with F2
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            //changed name of New to CustomerForm for reuse
            return View("CustomerForm", viewModel);
        }

        //restrict to POST request. do not allow any other requests to reach this action
        //Changed from Create to Save to handle Edit action as well
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //we will have an Id of 0 if Creating customer.
            //Id sent as hidden field in the form
            if (customer.Id == 0)
            {
                //add to DbContext
                _context.Customers.Add(customer);
            }
            else
            {
                //get the customer to edit
                //Single instead of SingleOrDefault since we know we have the customer
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //do not do TryUpdateModel(customerInDb) since it provides every key value pair
                //instead manually provide the exact keys and values to edit
                //could also use AutoMapper with Dto to only allow editing of specific key-value pairs
                //Mapper.Map(customerDto, customerInDb)

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            //add the DbContext to DB
            _context.SaveChanges();
            //redirect to Index view
            return RedirectToAction("Index", "Customers");
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