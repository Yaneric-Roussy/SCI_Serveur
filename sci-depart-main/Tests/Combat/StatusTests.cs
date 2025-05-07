using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Combat
{
    [TestClass]
    public class StatusTests
    {
        private ApplicationDbContext _db;

        [TestInitialize]
        public void Init()
        {
            string dbName = "StatusTests" + Guid.NewGuid().ToString();
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .UseLazyLoadingProxies(true) // Active le lazy loading
                .Options;

            _db = new ApplicationDbContext(options);
        }

        [TestMethod]
        public void HasStatusValid()
        {

        }

        [TestMethod]
        public void HasStatusNotValid()
        {

        }

        [TestMethod]
        public void AddStatusValueValid()
        {

        }

        [TestMethod]
        public void AddStatusNotValid()
        {

        }

        [TestMethod]
        public void GetStatusValueValid()
        {

        }

        [TestMethod]
        public void GetStatusValue()
        {

        }
    }
}
