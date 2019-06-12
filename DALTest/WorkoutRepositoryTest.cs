using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataAccessLayer;

namespace DALTest
{
    [TestFixture]
    class WorkoutRepositoryTest
    {
        IRepository<Workout> WorkoutRepo;
        [SetUp]
        public void SetUp()
        {
            WorkoutRepo = new WorkoutRepository();
        }
        
        [Test]
        public void GetAllTest()
        {
            var l = WorkoutRepo.GetAll().First();
            Assert.IsInstanceOf<Workout>(l);     
        }
        [Test]
        public void AddTest()
        {
            var workout = new Workout() { Name = "xxx", Workout_category = "pushups", Workout_title = "ABC" };
            var actual = WorkoutRepo.Add(workout);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void FindByIdTest()
        {
            var actual = WorkoutRepo.FindById(1);
            Assert.IsNotNull(actual);
        }
        [TearDown]
        public void CleanUp()
        {
            WorkoutRepo.Dispose();
        }
    }
}
