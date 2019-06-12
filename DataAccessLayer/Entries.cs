using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    public class Entries
    {
        [Key]
        public int EntryNo { get; set; }
        [ForeignKey("Workouts")]
        public int Workout_id { get; set; }
        public Workout Workouts { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="dd/mm/yyyy")]
        public DateTime start_date { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "hh:mm:ss")]
        public DateTime start_time { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime end_date { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "hh:mm:ss")]
        public DateTime end_time { get; set; }
        [Required]
        public string status { get; set; }
    }
}
