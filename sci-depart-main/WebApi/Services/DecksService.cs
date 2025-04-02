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
        
        public async Task AjoutDeck(string name)
        {
            Deck newDeck = new Deck();
            newDeck.Name = name;
            await _dbContext.Decks.AddAsync(newDeck);
            await _dbContext.SaveChangesAsync();
        }
        public IEnumerable<Deck> getDeck(string userId)
        {
            var player = _dbContext.Players.FirstOrDefault(p => p.UserId == userId);
    
                return _dbContext.Decks.Where(d => d.user.Id == userId).Include(s=>s.CarteJoueurs).ToList();
           
        }
       
    }
    
}
