using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WT_UserInterface.ViewModel;
using DataAccessLayer;
using WT_UserInterface.ViewModels;
namespace WT_UserInterface.Controllers
{
    public class StartController : Controller
    {
        public ActionResult Index()
        {
            var repo = new WorkoutRepository();
            var wl = repo.GetAll();
            var workoutslist = new List<WorkoutViewModel>();
            foreach(Workout w in wl)
            {
                workoutslist.Add( new WorkoutViewModel { Id =w.Id, Workout_title = w.Workout_title, Workout_category = w.Workout_category});
            }
            return View(workoutslist);
        }

        public ActionResult Add_workout()
        {

            return View();
        }

        public ActionResult Workout()
        {

            return View();
        }
    }
}