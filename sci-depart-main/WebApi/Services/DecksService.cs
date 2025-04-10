using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Collections;
using System.Reflection;

namespace WebApi.Services
{
    public class DecksService
        
    {

        private ApplicationDbContext _dbContext;
        private CardsService _cardsService;
        

        public DecksService(ApplicationDbContext dbContext , CardsService cardsService)
        {
            _dbContext = dbContext;
            _cardsService = cardsService;
        }

        public async Task AjoutDeck(string name,int playerId )
        {
            Player player = await _dbContext.Players.SingleOrDefaultAsync(p=>p.Id == playerId+1);
            var nbDeck =  await _dbContext.GameConfig.Select(x=>x.nbMaxDecks).FirstOrDefaultAsync();
            if (player.listeDeck.Count() < nbDeck)
            {
                Deck newDeck = new Deck();
                newDeck.Name = name;
                newDeck.Courant = false;
                newDeck.PlayerId = playerId;


                player.listeDeck.Add(newDeck);
                _dbContext.Decks.Add(newDeck);
                await _dbContext.SaveChangesAsync();
                

            }
            

           
        }
        public async Task<IEnumerable<Deck>> getDeck(int playerId)
        {
            List<Deck> deck = await _dbContext.Decks.Where(d => d.PlayerId == playerId).ToListAsync();
            return deck;
        }
        public async Task DeleteDeck(Deck deck)
        {
            if (deck.Courant!=true)
            {
                _dbContext.Remove(deck);
                _dbContext.SaveChanges();
            }
        }

        public async Task <Deck>  AddCarte(int playerId, int CarteID , int DeckID)

        {
            var maxCartes = await _dbContext.GameConfig.Select(x => x.nbMaxCartesDecks).FirstOrDefaultAsync();
            Player player = await _dbContext.Players.SingleOrDefaultAsync(p => p.Id == playerId + 1);
           List<Card>Cartes= _cardsService.GetAllCards().ToList();
            Card carteSelectione = Cartes.FirstOrDefault(x => x.Id == CarteID);
            Deck deck = _dbContext.Decks.FirstOrDefault(d => d.Id == DeckID);
            OwnedCard ownedCarte = new OwnedCard();

            if (player.OwnedCards.Count()<maxCartes)
            {
                ownedCarte.Card = carteSelectione;
                 deck.CarteJoueurs.Add(ownedCarte);
                _dbContext.OwnedCard.Add(ownedCarte);
                
                _dbContext.SaveChanges();
              
               

            }
            return deck;




        }


    }
    
}
