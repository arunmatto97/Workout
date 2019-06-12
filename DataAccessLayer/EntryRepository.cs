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

        public bool Update(Entries item)
            {
                try
                {

                var e = Context.entry.Find(item.EntryNo);
                    e.end_date = item.end_date;
                    e.status = item.status;
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

