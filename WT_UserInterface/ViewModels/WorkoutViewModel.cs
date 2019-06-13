using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WT_UserInterface.ViewModels
{
    public class WorkoutViewModel
    {
        
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [StringLength(50,ErrorMessage ="Title cannot be more than 50")]
        [Display(Name ="Workout Title")]
        [Required]
        public string Workout_title { get; set; }
        [Required]
        [Display(Name ="Category")]
        public string Workout_category { get; set; }
        [Required]
        [Display(Name = "CaloriesPerMinute ")]
        public int calories_perminute { get; set; }
        public string status { get; set; }
       
    }
}