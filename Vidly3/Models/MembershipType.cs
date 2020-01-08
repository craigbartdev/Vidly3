using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly3.Models
{
    public class MembershipType
    {
        //only 4 membership types so use byte
        //must be called id for foreign key recognition in Customer model
        public byte Id { get; set; }
        //manually added during
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        //short only allows values less than 32000
        public short SignUpFee { get; set; }
        //12 months is maximum number so use byte
        public byte DurationInMonths { get; set; }

        [Display(Name = "discount rate")]
        [Range(0, 100)]
        public byte DiscountRate { get; set; }


        //get rid of magic numbers in Min18 model
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}