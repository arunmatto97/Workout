using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WT_UserInterface.Validations;

namespace WT_UserInterface.ViewModels
{
    /// <summary>
    /// Represents workout entry in the workout table
    /// Second line in comment
    /// </summary>
    public class EntriesViewModel
    {   
        public int EntryNo { get; set; }
        public int Workout_id { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [EntryValidation(ErrorMessage ="Start date cannot be past date")]
        public DateTime start_date { get; set; }


        [Required]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}")]
        public DateTime start_time { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        // [EndDateValidation(ErrorMessage ="End date cannot be less than start date")]
        public DateTime? end_date { get; set; }
        
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}")]
        public DateTime? end_time { get; set; }


        [Required]
        [Display(Name = "CaloriesBurnt ")]
        public int calories_burnt { get; set; }
        [Display(Name ="EntryStatus")]
        public string entry_status { get; set; }

    }
}
