using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Reflection;


namespace WebApi.Hubs
{
    public class Chat: Hub
    {
        ApplicationDbContext _context;
        MatchesService _matchesService;
        IEnumerable<Match> Matches = new List<Match>();





        public Chat(ApplicationDbContext context, MatchesService matchesService)
        {
            _context = context;
            _matchesService = matchesService;
        }
        public override Task OnConnectedAsync()
        {
            // You can retrieve the user identifier from the context (e.g., from authentication)
            var userId = Context.UserIdentifier; // Here you can set a custom UserIdentifier based on your app's logic.
            return base.OnConnectedAsync();
        }

   
        
       public async Task UserPlaying()
        {

        }

        public async Task UserWatching()
        {

        }

        public async Task GetActiveMatches()
        {
               Matches = await _context.Matches.Where(m => m.IsMatchCompleted == false).ToListAsync();
          
            
       
        }
    }
}
