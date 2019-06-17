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
        public EntriesViewModel Work{ get; set; }
        public Workout Works{ get; set; }
        public int EntryNo { get; set; }
        public int Workout_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime? end_time { get; set; }
        public string entry_status { get; set; }
        public int? calories_burnt { get; set; }
       
    }
}