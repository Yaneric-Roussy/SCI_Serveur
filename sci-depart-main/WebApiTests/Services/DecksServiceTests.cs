using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Cartes_Infinies.Data;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Models;

namespace DeckService.Tests
{
    [TestClass()]
    public class DecksServiceTests

    {
        private ApplicationDbContext _db;
        [TestInitialize]
        public void Init()
        {
            // En utilisant un nom différent à chaque fois, on n'a pas besoin de retirer les données
            string dbName = "DeckService" + Guid.NewGuid().ToString();
            // TODO On initialise les options de la BD, on utilise une InMemoryDatabase
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // TODO il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                .UseInMemoryDatabase(databaseName: dbName)
                .UseLazyLoadingProxies(true) // Active le lazy loading
                .Options;

            _db = new ApplicationDbContext(options);
            Deck[] deck = new Deck[] {
    new Deck
    {
        Id = 1,
        Name = "Deck 1",
        Courant = true,
        PlayerId = 1,
        CarteJoueurs = new List<OwnedCard>(),
        CarteSuprime = new List<OwnedCard>()
    },
    new Deck
    {
        Id = 2,
        Name = "Deck 3",
        Courant = false,
        PlayerId = 1,
        CarteJoueurs = new List<OwnedCard>(),
        CarteSuprime = new List<OwnedCard>()
    }
};

            _db.AddRange(deck);
            _db.SaveChanges();

        }
        [TestCleanup]
        public void Dispose()
        {
            _db.Dispose();
}
        
      
        [TestMethod()]
        public void DecksServiceTest()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void AjoutDeckTest()
        {
          DecksService decksService = new DecksService(_db, null);
            Deck deckAjouter = new Deck();
            deckAjouter.Name = "Deck 2";
            deckAjouter.Courant = false;
            deckAjouter.PlayerId = 1;
            decksService.AjoutDeck("Deck 2", 1);

            Assert.AreEqual(deckAjouter.Name, "Deck 2");
            Assert.AreEqual(deckAjouter.Courant, false);
            Assert.AreEqual(deckAjouter.PlayerId, 1);
        }

        [TestMethod()]
        public void getDeckTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteDeckTest()
        {
            DecksService decksService = new DecksService(_db, null);
            decksService.DeleteDeck(_db.Decks.FirstOrDefault(d => d.Id == 2));
            Assert.IsNull(_db.Decks.FirstOrDefault(d => d.Id == 2));

        }

        [TestMethod()]
        public void AddCarteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCarteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeletedeckTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetCourantDeckTest()
        {
            Assert.Fail();
        }
    }
}