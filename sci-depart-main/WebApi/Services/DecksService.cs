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

        public async Task AjoutDeck(string name,string userID )
            
        {
            Player player = _dbContext.Players.SingleOrDefault(p=>p.UserId ==userID);
            var nbDeck = _dbContext.GameConfig.Select(x=>x.nbMaxDecks).FirstOrDefault();
            if (player.listeDeck.Count()<nbDeck)
            {
                Deck newDeck = new Deck();
                newDeck.Name = name;
                newDeck.Courant = false;


                player.listeDeck.Add(newDeck);
                _dbContext.Decks.Add(newDeck);
                await _dbContext.SaveChangesAsync();
                

            }
            

           
        }
        public async Task<IEnumerable<Deck>> getDeck(string userId)
        {
            List<Deck> deck = await _dbContext.Decks.Where(d => d.user.Id == userId).Include(s => s.CarteJoueurs).ThenInclude(Cj => Cj.Card).ToListAsync();
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
