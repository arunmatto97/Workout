using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT_Exception;
namespace DataAccessLayer
{
    public class EntryRepository:IRepository<Entries>
    {
        WorkoutContext Context;
        public EntryRepository()
        {
            Context = new WorkoutContext();
        }
        
       public bool Add(Entries item)
        {
            //throw new NotImplementedException();
            try
            {

                item.end_date = DateTime.Now.Date;
                item.end_time = DateTime.Now;
                var q = (from w in Context.work where w.Id == item.Workout_id select w).First();
                q.status = "active";
                Context.entry.Add(item);
                var isAdded = Context.SaveChanges()>0;
                return isAdded;

            }
            catch(DbException ex)
            {
                throw new WTException("Workout not started",ex);
            }
           
        }

        public bool Delete(Entries item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

            Context.Dispose();
        }

        public Entries FindById(int id)
        {
            try
            {
                return Context.entry.Find(id);
            }
            catch(DbException ex)
            {
                throw new WTException("Not found", ex);
            }
        }

        public List<Entries> GetAll()
        {
            try
            {  
            return Context.entry.ToList();
            }
            catch(DbException ex)
            {
                throw new WTException("NOT FOUND", ex);
            }
        }

        public Entries FindLastEntry(int Id)
        {
            var con = new WorkoutContext();
            var qry = from e in con.entry where e.Workout_id == Id || e.entry_status == "inprogress" select e;
            return qry.First();
        }
        public bool Update(Entries item)
            {
                try
                {

                //    var e = Context.entry.Find(item.EntryNo);
                //    e.end_date = item.end_date;
                //    e.end_date = item.end_time;
                     var qry = from e in Context.entry where e.entry_status != "completed" || e.Workout_id == item.Workout_id select e;
                     var close_entry = qry.First();
                     close_entry.end_date = item.end_date;
                     close_entry.end_time = item.end_time;
                     close_entry.entry_status = "completed";
                     var q = (from w in Context.work where w.Id == item.Workout_id select w).First();
                     q.status = "inactive";
                Context.SaveChanges();
                    return true;
                }
                catch (DbException ex)
                {
                    throw new WTException("invalid id", ex);
                }
            }


        }
    }

