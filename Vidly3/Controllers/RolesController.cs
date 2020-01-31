using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;
using System.Threading.Tasks;

namespace Vidly3.Controllers
{
    public class RolesController : Controller
    {
        //Use IdentityDbContext to access users and roles
        private ApplicationDbContext _context;

        //need a store to use the user manager
        private UserStore<ApplicationUser> _userStore;

        //need to use the user manager to get users from db. Uses Identity
        private UserManager<ApplicationUser> _userManager;

        //need a store to use the role manager
        private RoleStore<IdentityRole> _roleStore;

        //to get all of the roles
        private RoleManager<IdentityRole> _roleManager;

        //constructor to declare the above variables
        public RolesController()
        {
            //declare the context
            _context = new ApplicationDbContext();

            //create a user store from the context
            _userStore = new UserStore<ApplicationUser>(_context);

            //then a new instance of User Manager
            _userManager = new UserManager<ApplicationUser>(_userStore);

            //create a role store from the context
            _roleStore = new RoleStore<IdentityRole>(_context);

            //create store from context and create new instance of RoleManager
            _roleManager = new RoleManager<IdentityRole>(_roleStore);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            _userManager.Dispose();
            _roleManager.Dispose();
        }

        // GET: Users and Roles
        //must make into an async task because of asynchronous calls
        [Authorize(Roles = RoleName.CanManageUsers)]
        public async Task<ActionResult> Index()
        {
            //get all the users with User property of UserManager. make ToList for no more Db references.
            IEnumerable<ApplicationUser> UsersFromDB = _userManager.Users.ToList();

            //initialize an list which will be a list of models
            IList<RolesIndexViewModel> viewModels = new List<RolesIndexViewModel>();

            foreach (var user in UsersFromDB)
            {
                //Index takes IEnumerable of these models
                var viewModel = new RolesIndexViewModel()
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    //can be null. GetRolesAsync is method from UserManager. Returns list of strings.
                    Roles = await _userManager.GetRolesAsync(user.Id)
                };

                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }

        //get details of specific user
        //Roles/UserDetails/id
        [Authorize(Roles = RoleName.CanManageUsers)]
        public async Task<ActionResult> UserDetails(string id)
        {
            var UserFromDb = await _userManager.FindByIdAsync(id);

            var AllRolesFromDB = _roleManager.Roles.ToList();

            if (UserFromDb == null)
            {
                return HttpNotFound();
            }

            var viewModel = new RolesIndexViewModel()
            {
                UserId = id,
                UserEmail = UserFromDb.Email,
                Roles = await _userManager.GetRolesAsync(id),
                AllRoles = AllRolesFromDB
            };

            return View(viewModel);
        }
    }
}