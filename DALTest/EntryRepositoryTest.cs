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
    public class EntryRepositoryTest
    {
        IRepository<Entries> EntryRepo;
        [SetUp]
        public void SetUp()
        {
            EntryRepo = new EntryRepository();
        }
        [Test]
        public void AddTest()
        {
            var entry = new Entries() {Workout_id = 1,  start_date = DateTime.Parse("12/06/2019"), start_time = DateTime.Parse("12:00:23"), end_date = DateTime.Parse("12/06/2019"), end_time = DateTime.Parse("12:00:23") , status = "Inactive"};
            var result = EntryRepo.Add(entry);
            Assert.AreEqual(true,result);
        }
        [Test]
        public void GetAllTest()
        {
            var n1 = EntryRepo.GetAll().First();
            Assert.IsInstanceOf<Entries>(n1);
        }
        [Test]
        public void UpdateTest()
        {
            var entry = new Entries() { EntryNo = 6, start_date = DateTime.Parse("12/06/2019"), start_time = DateTime.Parse("12:00:23"), end_date = DateTime.Parse("12/06/2019"), end_time = DateTime.Parse("14:00:23"), status = "active" };
            Assert.AreEqual(true, EntryRepo.Update(entry));
        }
        [Test]
        public void FindByIdTest()
        {
            var actual = EntryRepo.FindById(6);
            Assert.IsNotNull(actual);
        }
        [TearDown]
        public void cleanup()
        {
            EntryRepo = null;
        }
    }
}
