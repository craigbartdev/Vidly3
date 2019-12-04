using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly3.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //navigation property is when you have include another modeltype in a model
        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        //entity recognizes this as a foreign key because of name
        public byte MembershipTypeId { get; set; }

        //make optional and give new name to show in view
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}