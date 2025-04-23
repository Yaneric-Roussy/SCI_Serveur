using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using static Super_Cartes_Infinies.Models.Card;

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

        // Une Probability possède : une value décimale (entre 0 et 1), une "rarity" et un "baseQty"

        // Faire une liste de rareté de carte à obtenir
        public List<Card.rareté> GenerateRarities(int nbCards, int defaultRarity, List<Probability> probabilities)
        {
            var rarities = new List<Card.rareté>();

            // Ajouter la quantité de base pour chaque probability à la liste
            foreach (Probability probability in probabilities)
            {
                for (int i = 0; i < probability.baseQty; i++)
                {
                    rarities.Add(probabilities[i].rarity);
                }
            }

            // Continuer de remplir la liste jusqu'à atteindre la quantité voulue
            while (rarities.Count < nbCards)
            {
                var rarity = GetRandomRarity(probabilites);


                //if (rarity == null)
                //            add defaultRarity to rarities
                //else
                //            add rarity to rarities
                //            }

                return rarities;
            }

            // Cette méthode permet d'obtenir une rareté au hasard
            public Card.rareté? GetRandomRarity(List<Probability> probabilities)
            {
               var X = Random Number Between 0 and 1


    for each rarity of probabilities{
                    if probability.value < X{
                        return probability.rarity}
                    else:
            X -= probability.value
                }


    return null
                         }



    }
}

