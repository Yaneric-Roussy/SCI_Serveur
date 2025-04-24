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

        public Pack GetPackId(int id)
        {
            return _dbContext.Packs.Where(i => i.Id == id).FirstOrDefault();
        }

        // Une Probability possède : une value décimale (entre 0 et 1), une "rarity" et un "baseQty"

        // Faire une liste de rareté de carte à obtenir
        public static List<Card.rareté> GenerateRarities(int nbCards, rareté defaultRarity, List<Probability> probabilities)
        {
            var rarities = new List<rareté>();

            // 1) Ajouter la quantité de base pour chaque probabilité
            foreach (var p in probabilities)
                for (int i = 0; i < p.BaseQty; i++)
                    rarities.Add(p.Rarity);

            // 2) Normaliser les probabilités si leur somme ≠ 1
            double total = probabilities.Sum(p => p.Value);
            if (total > 0 && Math.Abs(total - 1.0) > 1e-6)
            {
                foreach (var p in probabilities)
                    p.Value /= total;
            }

            // 3) Tirages supplémentaires jusqu'à nbCards
            var rnd = new Random();
            while (rarities.Count < nbCards)
            {
                var chosen = GetRandomRarity(probabilities, rnd);
                rarities.Add(chosen ?? defaultRarity);
            }

            return rarities;
        }

        private static rareté? GetRandomRarity(List<Probability> probabilities, Random rnd)
        {
            double x = rnd.NextDouble(); // [0,1)
            foreach (var p in probabilities)
            {
                if (x < p.Value)
                    return p.Rarity;
                x -= p.Value;
            }
            // Par sécurité en cas d’erreur numérique
            return null;
        }
        public List<Card> BuildPack(   List<rareté> rarities,   Dictionary<rareté, List<Card>> cardsByRarity)
        {
            var pack = new List<Card>(rarities.Count);
            var rnd = new Random();

            foreach (var rarity in rarities)
            {
                // Récupère la liste des cartes de cette rareté
                if (!cardsByRarity.TryGetValue(rarity, out var available)
                    || available.Count == 0)
                {
                    throw new InvalidOperationException(
                        $"Aucune carte disponible pour la rareté {rarity}");
                }

                // Pioche une carte aléatoire (doublons possibles)
                int index = rnd.Next(available.Count);
                pack.Add(available[index]);
            }

            return pack;
        }


    }
}

