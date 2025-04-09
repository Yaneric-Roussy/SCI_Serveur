using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Collections;

namespace WebApi.Services
{
    public class DecksService
        
    {

        private ApplicationDbContext _dbContext;
        

        public DecksService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AjoutDeck(string name,int playerId )
        {
            Player player = await _dbContext.Players.SingleOrDefaultAsync(p=>p.Id == playerId);
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
        public void DeleteDeck(Deck deck)
        {
            if (deck.Courant!=true)
            {
                _dbContext.Remove(deck);
                _dbContext.SaveChanges();
            }
        }

       
    }
    
}
