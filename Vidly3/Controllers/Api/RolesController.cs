using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vidly3.Models;

namespace Vidly3.Controllers.Api
{
    public class RolesController : ApiController
    {
        private ApplicationDbContext _context;

        //declare the store since we need it separately to save changes
        private UserStore<ApplicationUser> _userStore;

        private UserManager<ApplicationUser> _userManager;

        public RolesController()
        {
            _context = new ApplicationDbContext();
            _userStore = new UserStore<ApplicationUser>(_context);
            _userManager = new UserManager<ApplicationUser>(_userStore);
        }

        [Route("api/ChangeRole/{userId}/{roleName}/{isInRole:bool}")]
        [Authorize(Roles = RoleName.CanManageUsers)]
        [HttpPut]
        public async Task<IHttpActionResult> ToggleRole(string userId, string roleName, bool isInRole)
        {
            if (isInRole)
            {
                var roleResult = await _userManager.AddToRoleAsync(userId, roleName);

                //succeeded is the boolean value of whether the result was a success
                if (roleResult.Succeeded)
                {
                    //save changes from context
                    _context.SaveChanges();

                    return Ok();
                } else
                {
                    return NotFound();
                }

            } else {
                var roleResult = await _userManager.RemoveFromRoleAsync(userId, roleName);

                if (roleResult.Succeeded)
                {
                    //save changes from context
                    _context.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
