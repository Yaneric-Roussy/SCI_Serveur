using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
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
        
        public async Task AjoutDeck(string name,string userid)
        {
            var gameCnfigue = _dbContext.GameConfig.First();
            Deck newDeck = new Deck();
            if (newDeck.nbMaxCarte!=gameCnfigue.nbMaxCartesDecks)
            {
                newDeck.Name = name;


                await _dbContext.SaveChangesAsync();

            }
           
           
        }
        public IEnumerable<Deck> getDeck(string userId)
        {
                return _dbContext.Decks.Where(d => d.user.Id == userId).Include(s=>s.CarteJoueurs).ThenInclude(Cj=> Cj.Card).ToList();
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
