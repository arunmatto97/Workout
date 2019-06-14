namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.WorkoutContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.WorkoutContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.work.AddOrUpdate(p => p.Workout_title,
            new Workout() { Workout_title = "Aerobics", Workout_category = "Build_Strength" },
             new Workout() { Workout_title = "PushUps", Workout_category = "Calisthenics" },
             new Workout()  { Workout_title = "Squats", Workout_category = "Weight_Lifting" },
              new Workout()  { Workout_title = "Deadlifts", Workout_category = "Weight_Lifting" },
              new Workout()   {  Workout_title = "Handstands", Workout_category = "Calisthenics" }
              );








        }
    }
}
