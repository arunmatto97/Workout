using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WT_UserInterface.Validations
{
    public class EntryValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var startdate = DateTime.Parse(value.ToString());
                if (startdate >= DateTime.Now.Date)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(base.ErrorMessage ?? "Cannot be a past date");

                }
            }
            //else
            //{
            //    return new ValidationResult(base.ErrorMessage ?? "Cannot be blank");
            //}
            return new ValidationResult(base.ErrorMessage ?? "Cannot be blank");

        }
    }
}