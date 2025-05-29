using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
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
            //var status = new Status { Id = 1, Name = "Poison", Description = "Fait mal" };
            var card = new Card();
            var playable = new PlayableCard(card);

            playable.PlayableCardsStatus.Add(new PlayableCardStatus
            {
                StatusId = 1,
                Value = 2
            });

            Assert.IsTrue(playable.HasStatus(1));
        }

        [TestMethod]
        public void HasStatusNotValid()
        {
            var card = new Card();
            var playable = new PlayableCard(card);

            Assert.IsFalse(playable.HasStatus(2134));
        }

        [TestMethod]
        public void AddStatusValueValid()
        {
            //var status = new Status { Id = 1, Name = "Shield", Description = "Protège" };
            var card = new Card();
            var playable = new PlayableCard(card);

            playable.AddStatusValue(1, 3);

            Assert.AreEqual(1, playable.PlayableCardsStatus.Count);
            Assert.AreEqual(3, playable.PlayableCardsStatus[0].Value);
        }

        [TestMethod]
        public void AddStatusValueNotValid()
        {
            //var status = new Status { Id = 1, Name = "Shield", Description = "Protège" };
            var card = new Card();
            var playable = new PlayableCard(card);

            playable.AddStatusValue(1, 5);

            Assert.AreEqual(1, playable.PlayableCardsStatus.Count);
            Assert.AreNotEqual(10, playable.PlayableCardsStatus[0].Value);
        }

        [TestMethod]
        public void GetStatusValueValid()
        {
            //var status = new Status { Id = 1, Name = "Rage" };
            var card = new Card();
            var playable = new PlayableCard(card);

            playable.AddStatusValue(1, 10);

            int value = playable.GetStatusValue(1);
            Assert.AreEqual(10, value);
        }

        [TestMethod]
        public void GetStatusValue()
        {
            var card = new Card();
            var playable = new PlayableCard(card);

            int value = playable.GetStatusValue(3214);
            Assert.AreEqual(0, value);
        }
    }
}
