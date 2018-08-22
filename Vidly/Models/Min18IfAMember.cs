using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18IfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo || customer.MembershipTypeId == MembershipType.Unknown) { return ValidationResult.Success; }
            if (customer.DateofBirth == null) { return new ValidationResult("Please enter birthdate"); }
            var age = DateTime.Now.Year - customer.DateofBirth.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at lease 18 years old");
        }

    }
}