using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using WT_UserInterface.Validations;
namespace WT_UserInterface.ViewModels
    
{
    public class ReportViewModel
    {
        public Entries Work{ get; set; }
        public Workout Works{ get; set; }
       
           
}
}