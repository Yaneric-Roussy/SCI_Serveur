using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
        
        //public async Task AjoutDeck(string name,string userid)
        //{
        //    var gameCnfigue = _dbContext.GameConfig.First();
        //    Deck newDeck = new Deck();
        //    _dbContext.Decks.AddAsync(newDeck);
        //    await _dbContext.SaveChangesAsync();

        //}
        public async Task<List<Deck>> getDeck(string userId)
        {

            //var temp = await _dbContext.Decks.Where(d => d.UserId == userId).ToListAsync();
            var haha = _dbContext.Decks.Where(d => d.UserId == userId).ToListAsync();
            return await _dbContext.Decks.Where(d => d.UserId == userId).ToListAsync();
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
