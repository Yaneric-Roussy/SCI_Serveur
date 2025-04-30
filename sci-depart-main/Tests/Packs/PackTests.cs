using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Tests.Packs
{
    [TestClass()]
    public class PackTests
    {
        private ApplicationDbContext _db;
        [TestInitialize]
        public void Init()
        {
            string dbName = "PackPurchaseTests" + Guid.NewGuid().ToString();
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .UseLazyLoadingProxies(true) // Active le lazy loading
                .Options;

            _db = new ApplicationDbContext(options);

            List<Pack> packs = new List<Pack>
            {
                new Pack { Id = 1, Name = "Normal Pack", NbCard = 4, Cost = 300, Type = Pack.type.Normal, Rareté = Pack.raretéPack.Commune },
                new Pack { Id = 2, Name = "Super Pack", NbCard = 5, Cost = 500, Type = Pack.type.Super, Rareté = Pack.raretéPack.Épique }
            };

            List<Probability> probabilities = new List<Probability>
            {
                new Probability { Id = 1, Value = 0.3, Rarity = Card.rareté.Rare, BaseQty = 0, PackId = 1},
                new Probability { Id = 2, Value = 0.3, Rarity = Card.rareté.Épique, BaseQty = 1, PackId = 2}
            }; 
            List<Card> cards = new List<Card>
            {
                new Card { Id = 1, Name = "Common Card", Rareté = Card.rareté.Commune },
                new Card { Id = 2, Name = "Rare Card", Rareté = Card.rareté.Rare },
                new Card { Id = 3, Name = "Epic Card", Rareté = Card.rareté.Épique },
                new Card { Id = 4, Name = "Legendary Card", Rareté = Card.rareté.Légendaire }
            };

            _db.AddRange(packs);
            _db.AddRange(cards);
            _db.AddRange(probabilities);
            _db.Players.Add(new Player { Id = 1, UserId = "test-user", Money = 1000 });
            _db.SaveChanges();
        }

        [TestCleanup]
        public void Dispose()
        {
            _db.Dispose();
        }

        [TestMethod()]
        public void AchatPackRetourneLeBonnmombredecardetreduitargent()
        {
            // Arrange
            CardsService cardsService = new CardsService(_db);
            var player = _db.Players.First();
            player.Money = 500; // Sufficient money
            var pack = _db.Packs.First(p => p.Type == Pack.type.Normal); // Normal pack
            var initialMoney = player.Money;

            // Act
            var cards = cardsService.BuildPack(pack.Id, player.UserId);

            // Assert
            Assert.AreEqual(pack.NbCard, cards.Count, "Le nombre de cartes reçues ne correspond pas au nombre attendu.");
            Assert.AreEqual(initialMoney - pack.Cost, player.Money, "L'argent n'a pas été correctement déduit.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PurchasePack_FailsIfNotEnoughMoney()
        {
            // Arrange
            CardsService cardsService = new CardsService(_db);
            var player = _db.Players.First();
            player.Money = 50; // Insufficient money
            var pack = _db.Packs.First(p => p.Type == Pack.type.Normal); // Normal pack

            // Act
            cardsService.BuildPack(pack.Id, player.UserId);

            // Assert
            // Une exception est attendue, donc aucun Assert supplémentaire n'est nécessaire.

        }

        [TestMethod]
        public void PurchaseSuperPack_ContainsNoCommonCardsAndAtLeastOneEpic()
        {
            // Arrange
            CardsService cardsService = new CardsService(_db);
            var player = _db.Players.First();
            player.Money = 1000; // Sufficient money
            var pack = _db.Packs.First(p => p.Type == Pack.type.Super); // Super pack

            // Act
            var cards = cardsService.BuildPack(pack.Id, player.UserId);

            // Assert
            Assert.IsTrue(cards.All(c => c.Rareté != Card.rareté.Commune), "Le pack Super contient des cartes communes.");
            Assert.IsTrue(cards.Any(c => c.Rareté == Card.rareté.Épique), "Le pack Super ne contient pas de carte épique.");
        }
    }
}
