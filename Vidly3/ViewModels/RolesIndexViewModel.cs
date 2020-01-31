using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly3.Models;

namespace Vidly3.ViewModels
{
    public class RolesIndexViewModel
    {   
        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public IList<IdentityRole> AllRoles { get; set; }
    }
}