using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WT_UserInterface.ViewModels;
using WT_UserInterface;
using DataAccessLayer;

namespace WT_UserInterface.Validations
{
    public class EndDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var entrydate = (EntriesViewModel)validationContext.ObjectInstance;

                if (entrydate.end_date >= entrydate.start_date)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(base.ErrorMessage ?? "Cannot be a less than start  date");

                }
            }
                return new ValidationResult(base.ErrorMessage ?? "Cannot be blank");
            
        }
    }
}