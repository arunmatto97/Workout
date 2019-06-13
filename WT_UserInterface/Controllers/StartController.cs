using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WT_UserInterface.ViewModels;
using DataAccessLayer;

namespace WT_UserInterface.Controllers
{
    public class StartController : Controller
    {
        IRepository<Workout> workrepo;
        public StartController()
        {
            workrepo = new WorkoutRepository();
        }
        public ActionResult Index()
        {
            var repo = new WorkoutRepository();
            var wl = repo.GetAll();
            var workoutslist = new List<WorkoutViewModel>();
            foreach (Workout w in wl)
            {
                workoutslist.Add(new WorkoutViewModel { Id = w.Id, Workout_title = w.Workout_title, Workout_category = w.Workout_category });
            }
            return View(workoutslist);
        }

        public ActionResult Add_workout()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add_workout(WorkoutViewModel workoutView)
        {
            if (ModelState.IsValid)
            {
                var workout = new Workout() { Id = workoutView.Id, Name = workoutView.Name, Workout_category = workoutView.Workout_category, Workout_title = workoutView.Workout_title, status = "inactive",calories_perminute =workoutView.calories_perminute  };
                var isAdded = workrepo.Add(workout);
                if (isAdded)
                {
                    return RedirectToAction("");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add");
                    return View(workoutView);
                }
            }
            else
            {
                ModelState.AddModelError("", "One or more validations failed");
                return View(workoutView);
            }
        }


        public ActionResult Workout(WorkoutViewModel view)
        {

            var lists = workrepo.FindById(view.Id);



            return View(lists);



        }
        [HttpPost]
        public ActionResult Workoutview(EntriesViewModel view)
        {
            if (ModelState.IsValid)
            {
                var entryrepo = new EntryRepository();
                var entry = new Entries() { EntryNo = view.EntryNo,Workout_id = view.Workout_id, start_date = view.start_date, start_time = view.start_time };
                var isAdded = entryrepo.Add(entry);
                if (isAdded)
                {
                    return RedirectToAction("");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add");
                    return View(view);
                }
            }
            else
            {
                ModelState.AddModelError("", "One or more validations failed");
                return View(view);


            }
        }
    }
}
