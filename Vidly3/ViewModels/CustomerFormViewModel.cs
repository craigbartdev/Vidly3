using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly3.Models;

namespace Vidly3.ViewModels
{
    public class CustomerFormViewModel
    {
        //IEnumerable only allows you to get values. List would mean add, update, delete functionality.
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        //can only select specific properties, but here we will not because we need to define everything
        public Customer Customer { get; set; }
        //conditionally render title in CustomerForm view
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edit Customer";
                return "New Customer";
            }
        }
    }
}