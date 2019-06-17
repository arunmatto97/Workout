using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WT_UserInterface.ViewModels;
using DataAccessLayer;
using System.Data.Entity.Infrastructure;

namespace WT_UserInterface.Controllers
{
    [HandleError(View = "Error")]
    public class StartController : Controller
    {
        WorkoutRepository workrepo;
        EntryRepository entryrepo;
        public StartController()
        {
            workrepo = new WorkoutRepository();
            entryrepo = new EntryRepository();
        }
       
        public ActionResult Index()
        {
            var wl = workrepo.GetAll();
            var workoutslist = new List<WorkoutViewModel>();
            foreach (Workout w in wl)
            {
                workoutslist.Add(new WorkoutViewModel { Id = w.Id, Workout_title = w.Workout_title, Workout_category = w.Workout_category,calories_perminute = w.calories_perminute, status=w.status});
            }
            //ViewBag.Data = workoutslist;
            return View(workoutslist);
        }

        //public ActionResult check(int id)
        //{
        //    var context = new WorkoutContext();
        //    var selected = context.work.Find(id);
        //    if(selected.status=="inactive")
        //    return RedirectToAction("StartWorkout");
        //    return RedirectToAction("EndWorkout");
        //}
       

        public ActionResult Add_workout()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add_workout(WorkoutViewModel workoutView)
        {
            if (ModelState.IsValid)
            {
                var workout = new Workout() { Id = workoutView.Id, Workout_category = workoutView.Workout_category, Workout_title = workoutView.Workout_title, status = "inactive",calories_perminute =workoutView.calories_perminute  };
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
       
        public ActionResult StartWorkout(int Id)
        {
            var con = new WorkoutContext();
            var sel = con.work.Find(Id);

            var new_entry = new EntriesViewModel() { Workout_id = sel.Id, start_date = DateTime.Now.Date, start_time = DateTime.Now,end_date=null,end_time=DateTime.Parse("00:00:00")};
           // var selwork = new WorkoutViewModel() {Id =sel.Id, Name=sel.Name, Workout_title = sel.Workout_title, Workout_category=sel.Workout_category,calories_perminute=sel.calories_perminute};
          //  ViewBag.data = selwork;

            return View(new_entry);
        }
     
        [HttpPost]
        
        public ActionResult StartWorkout(EntriesViewModel view)
        {
            if (ModelState.IsValid)
            {
                var entryrepo = new EntryRepository();
                var entry = new Entries() { EntryNo = view.EntryNo,Workout_id = view.Workout_id, start_date = view.start_date, start_time = view.start_time, entry_status = "inprogress"};
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
        
        public ActionResult EndWorkout(int Id)
        {
            //var con = new WorkoutContext();
            //var qry = from e in con.entry where e.Workout_id == Id || e.entry_status == "inprogress" select e;
            var sel = entryrepo.FindLastEntry(Id);
            var end_entry = new EntriesViewModel() { Workout_id = sel.Workout_id, end_date = DateTime.Now.Date, end_time = DateTime.Now, calories_burnt =200 };
            
            return View(end_entry);
        }

        [HttpPost]
       
        public ActionResult EndWorkout(EntriesViewModel uentry)
        {
            //var con = new WorkoutContext();
            //var qry = from e in con.entry where e.entry_status != "completed" || e.Workout_id == uentry.Workout_id select e;
            //var close_entry = qry.First();
            //close_entry.end_date = uentry.end_date;
            //close_entry.end_time = uentry.end_time;
            //close_entry.entry_status = "completed";
            var close_entry = new Entries() { Workout_id = uentry.Workout_id, end_date = uentry.end_date, end_time = uentry.end_time, calories_burnt = 200 };
              var entries = entryrepo.Update(close_entry);
            
            return RedirectToAction("");
        }

        public ActionResult View_Report()
        {
            return View();

             // var entries = entryrepo.Update(close_entry);
            
           // return RedirectToAction("");
        }
        public ActionResult Report_Data(EntriesViewModel sd, EntriesViewModel ed)
        {

            var wtit = entryrepo.GetAll();
            var reportlist = new List<ReportViewModel>();
            foreach (var w in wtit)
            {
                if (w.start_date >= sd.start_date || w.end_date <= ed.end_date)
                {
                    // var workouttitle = workrepo.GetAll().Find(w.Workout_id);
                    reportlist.Add(new ReportViewModel { Workout_id = w.Workout_id, EntryNo = w.EntryNo, start_time = w.start_time, end_time = w.end_time, entry_status = w.entry_status, calories_burnt = w.calories_burnt });
                }
            }
            return View(reportlist);

        }
    }
}
