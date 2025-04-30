
﻿using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using System.Collections.Generic;
using WebApi.Services;
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

        public async Task<IEnumerable<Card>> GetUserDeckCards(int playerId)
        {
            Deck deck = await _dbContext.Decks.Where(d => d.PlayerId == playerId && d.Courant).FirstOrDefaultAsync();
            List<Card> listCARTE = new List<Card>();

            if (deck == null)
                throw new NullReferenceException();

            foreach (OwnedCard ownedCard in deck.CarteJoueurs)
            {
                listCARTE.Add(ownedCard.Card);
            }
            return listCARTE;


            //foreach (Deck deck in deckList)
            //{
            //    if (deck.Courant)
            //    {
            //        foreach (OwnedCard ownedCard in deck.CarteJoueurs)
            //        {
            //            listCARTE.Add(ownedCard.Card);
            //        }
            //        return listCARTE;
            //    }
            //}
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
        public List<Card.rareté> GenerateRarities(int nbCards, Card.rareté defaultRarity, List<Probability> probabilities)
        {
            var rarities = new List<Card.rareté>();

            // 1. Ajouter la quantité de base pour chaque probabilité
            foreach (var probability in probabilities)
            {
                for (int i = 0; i < probability.BaseQty; i++)
                {
                    rarities.Add(probability.Rarity);
                }
            }

            // 2. Remplir la liste jusqu'à atteindre le nombre de cartes souhaité
            var rnd = new Random();
            while (rarities.Count < nbCards)
            {
                var rarity = GetRandomRarity(probabilities, rnd);

                if (rarity == null)
                {
                    rarities.Add(defaultRarity);
                }
                else
                {
                    rarities.Add(rarity.Value);
                }
            }

            return rarities;
        }

        private Card.rareté? GetRandomRarity(List<Probability> probabilities, Random rnd)
        {
            double x = rnd.NextDouble(); // Génère un nombre aléatoire entre 0 et 1

            foreach (var probability in probabilities)
            {
                if (x < probability.Value)
                {
                    return probability.Rarity;
                }
                x -= probability.Value;
            }

            // Retourne null en cas d'erreur numérique
            return null;
        }
        public List<Card> BuildPack(int packId, string userId)
        {
            // Récupérer le pack et ses probabilités
            var pack = _dbContext.Packs.Where(p => p.Id == packId).FirstOrDefault();
            if (pack == null)
            {
                throw new ArgumentException($"Le pack avec l'ID {packId} n'existe pas.");
            }

            var user = _dbContext.Players.Where(p => p.UserId == userId).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentException($"L'utilisateur avec l'ID {userId} n'existe pas.");
            }

            // Vérifier si le joueur a assez d'argent
            if (user.Money < pack.Cost)
            {
                throw new InvalidOperationException("Vous n'avez pas assez d'argent pour acheter ce pack.");
            }

            var probabilities = _dbContext.Probabilities
                .Where(p => p.PackId == packId)
                .ToList();

            if (!probabilities.Any())
            {
                throw new InvalidOperationException($"Aucune probabilité définie pour le pack {pack.Name}.");
            }

            // Générer les raretés des cartes
            var rarities = GenerateRarities(pack.NbCard, (Card.rareté)pack.Rareté, probabilities);

            // Construire le pack de cartes
            var cards = new List<Card>();
            var rnd = new Random();
            bool hasEpicCard = false;
            foreach (var rarity in rarities)
            {
                // Récupérer les cartes disponibles pour cette rareté
                var availableCards = _dbContext.Cards
                    .Where(c => c.Rareté == rarity)
                    .ToList();

                if (!availableCards.Any())
                {
                    throw new InvalidOperationException($"Aucune carte disponible pour la rareté {rarity}.");
                }

                // Sélectionner une carte aléatoire
                var randomCard = availableCards[rnd.Next(availableCards.Count)];
                cards.Add(randomCard);

                // Vérifier si une carte épique est obtenue
                if (randomCard.Rareté == Card.rareté.Épique)
                {
                    hasEpicCard = true;
                }
            }

            // Vérifier les règles spécifiques au pack le plus cher
            if (pack.Type == Pack.type.Super)
            {
                if (cards.Any(c => c.Rareté == Card.rareté.Commune))
                {
                    throw new InvalidOperationException("Les cartes communes ne sont pas autorisées dans le pack Super.");
                }

                if (!hasEpicCard)
                {
                    throw new InvalidOperationException("Le pack Super doit contenir au moins une carte épique.");
                }
            }

            // Déduire le coût du pack du solde du joueur
            user.Money -= pack.Cost;

            // Ajouter les cartes obtenues à la collection du joueur
            foreach (var card in cards)
            {
                var ownedCard = new OwnedCard { Card = card, Player = user };
                _dbContext.OwnedCard.Add(ownedCard);
            }

            // Sauvegarder les modifications dans la base de données
            _dbContext.SaveChanges();

            return cards;
        }



    }
}

