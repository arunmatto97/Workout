using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    /// <summary>
    /// Represents workout entry in the workout table
    /// Second line in comment
    /// </summary>
    public class Entries
    {
        [Key]
        public int EntryNo { get; set; }
        [ForeignKey("Workouts")]
        public int Workout_id { get; set; }
        public Workout Workouts { get; set; }       
        public DateTime start_date { get; set; }       
        public DateTime start_time { get; set; }             
        public DateTime? end_date { get; set; }          
        public DateTime end_time { get; set; }
        public int? calories_burnt { get; set; }
        public string entry_status { get; set; }
    }
}
