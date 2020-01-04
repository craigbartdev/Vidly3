using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly3.Models;
using Vidly3.Dtos;

namespace Vidly3.Dtos
{
    //dto for relaying data from server to client
    //used in api/customerscontroller
    public class CustomerDto
    {
        public int Id { get; set; }

        //no need for custom error messages
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //entity recognizes this as a foreign key because of name
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //comment out min18years when using IHttpActionResult unless we change it to use a dto
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        //to mark customer as delinquent
        //make nullible to set the initial value to false in the POST action
        public bool? IsDelinquent { get; set; }
    }
}