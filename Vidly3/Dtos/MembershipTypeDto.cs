using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly3.Dtos
{
    //to be referenced in CustomerDto
    //only need what we need to show in the Index view
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}