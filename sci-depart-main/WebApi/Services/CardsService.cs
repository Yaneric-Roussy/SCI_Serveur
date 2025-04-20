using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class CardsService
    {
        private ApplicationDbContext _dbContext;

        public CardsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Card> GetPlayersCards(string userId)
        {
            // Récupérer les cartes possédées par le joueur en utilisant l'ID de l'utilisateur
            var player = _dbContext.Players.FirstOrDefault(p => p.UserId == userId);
            if (player == null)
            {
                return new List<Card>();
            }

            var ownedCards = _dbContext.OwnedCard
                .Where(oc => oc.Player.Id == player.Id)
                .Select(oc => oc.Card)
                .ToList();

            return ownedCards;
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _dbContext.Cards;
        }

        public IEnumerable<Pack> GetPacks()
        {
            return _dbContext.Packs;
        }
    }
}

