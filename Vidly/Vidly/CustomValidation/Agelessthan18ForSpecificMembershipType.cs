using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.CustomValidation
{
    public class Agelessthan18ForSpecificMembershipType : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == Customer.MemberTypePayAsUGo || customer.MembershipTypeId == Customer.MemberIdNull)
            {
                return ValidationResult.Success;
            }

            if (customer.DateOfBirth == null)
            {
                return new ValidationResult("BirthDate cannot be null");
            }

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;

            return age > 18
                ? ValidationResult.Success
                : new ValidationResult("Not eligible for this membership type please select Pay As you Go option");
        }

    }
}