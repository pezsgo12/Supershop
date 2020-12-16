using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Validation
{
    public sealed class StartsWithUppercaseAttribute : ValidationAttribute
    {
        public StartsWithUppercaseAttribute()
        {
            ErrorMessage = "Must start with uppercase";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // TODO: Check if string; check length

            if (char.IsUpper(value.ToString()[0]))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
