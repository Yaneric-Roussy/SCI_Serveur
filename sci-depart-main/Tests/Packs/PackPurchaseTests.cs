using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Services
{
    [TestClass]
    public class PackPurchaseTests : BaseTests
    {
        private CardsService _cardsService;
        private ApplicationDbContext _dbContext;
        public PackPurchaseTests(CardsService cardsService, ApplicationDbContext dbContext)
        {
            _cardsService = cardsService;
            _dbContext = dbContext;
        }


        [TestInitialize]
        protected void Init()
        {


            // Ajouter des packs
            _dbContext.Packs.AddRange(new List<Pack>
    {
        new Pack { Id = 1, Name = "Normal Pack", NbCard = 4, Cost = 300, Type = Pack.type.Normal },
        new Pack { Id = 2, Name = "Super Pack", NbCard = 5, Cost = 500, Type = Pack.type.Super }
            });

            // Ajouter des cartes
            _dbContext.Cards.AddRange(new List<Card>
    {
        new Card { Id = 1, Name = "Common Card", Rareté = Card.rareté.Commune },
        new Card { Id = 2, Name = "Rare Card", Rareté = Card.rareté.Rare },
        new Card { Id = 3, Name = "Epic Card", Rareté = Card.rareté.Épique },
        new Card { Id = 4, Name = "Legendary Card", Rareté = Card.rareté.Légendaire }
    
            });

            // Ajouter un joueur
            _dbContext.Players.Add(new Player { Id = 1, UserId = "test-user", Money = 1000 });

            _dbContext.SaveChanges();
        }


        [TestMethod]
        public void AchatPackRetourneLeBonnmombredecardetreduitargent()
        {
            // Arrange
            var player = _dbContext.Players.First();
            player.Money = 500; // Sufficient money
            var pack = _dbContext.Packs.First(p => p.Type == Pack.type.Normal); // Normal pack
            var initialMoney = player.Money;

            // Act
            var cards = _cardsService.BuildPack(pack.Id, player.UserId);

            // Assert
            Assert.AreEqual(pack.NbCard, cards.Count, "Le nombre de cartes reçues ne correspond pas au nombre attendu.");
            Assert.AreEqual(initialMoney - pack.Cost, player.Money, "L'argent n'a pas été correctement déduit.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PurchasePack_FailsIfNotEnoughMoney()
        {
            // Arrange
            var player = _dbContext.Players.First();
            player.Money = 50; // Insufficient money
            var pack = _dbContext.Packs.First(p => p.Type == Pack.type.Normal); // Normal pack

            // Act
            _cardsService.BuildPack(pack.Id, player.UserId);

            // Assert
            // Une exception est attendue, donc aucun Assert supplémentaire n'est nécessaire.
    
        }

        [TestMethod]
        public void PurchaseSuperPack_ContainsNoCommonCardsAndAtLeastOneEpic()
        {
            // Arrange
            var player = _dbContext.Players.First();
            player.Money = 1000; // Sufficient money
            var pack = _dbContext.Packs.First(p => p.Type == Pack.type.Super); // Super pack

            // Act
            var cards = _cardsService.BuildPack(pack.Id, player.UserId);

            // Assert
            Assert.IsTrue(cards.All(c => c.Rareté != Card.rareté.Commune), "Le pack Super contient des cartes communes.");
            Assert.IsTrue(cards.Any(c => c.Rareté == Card.rareté.Épique), "Le pack Super ne contient pas de carte épique.");
        }
    }
}
