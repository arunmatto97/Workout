namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WorkoutContext : DbContext
    {
        // Your context has been configured to use a 'Workouts' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccessLayer.Workouts' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Workouts' 
        // connection string in the application configuration file.
        public WorkoutContext()
            : base("name=Workouts")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Workout> work { get; set; }
        public virtual DbSet<Entries> entry { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}