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
    /// this is test
    /// </summary>
    public class Workout
    {
        [Key]
        public int Id { get; set; }
       
        public string Name { get; set; }
        [StringLength(50)]
        
        public string Workout_title { get; set; }
      
        public string Workout_category { get; set; }
        public virtual ICollection<Entries> Entry { get; set; }
    }
}
