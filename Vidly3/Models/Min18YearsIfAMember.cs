using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly3.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validationContext.Object gives access to Customer class object
            //need to change to Dto if you want this to work with the api
            var customer = (Customer)validationContext.ObjectInstance;

            //if membership type is select membership type or pay as you go 
            //no error message will show up on birthdate
            //we have magic numbers so we will replace them
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            //require a birthdate
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");
            //simple year calculation. not quite perfect
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            //show error message when too young
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer must be 18+ years old to have membership");
        }
    }
}