using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WT_UserInterface.ViewModel
{
    public class EntriesViewModel
    {
        public int EntryNo { get; set; }
        public int Workout_id { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime start_date { get; set; }


        [Required]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}")]
        public DateTime start_time { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime end_date { get; set; }
        
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}")]
        public DateTime end_time { get; set; }


        public string status { get; set; }

    }
}
