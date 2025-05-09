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
        List<Match> Matches = new List<Match>();




        public Chat(ApplicationDbContext context, MatchesService matchesService)
        {
            _context = context;
            _matchesService = matchesService;
        }
        //private static Dictionary<string, string> _userConnections = new();
        private string signalRId
        {
            get { return Context.ConnectionId!; }
        }
        private string userId
        {
            get { return Context.UserIdentifier!; }
        }
        private string WriteGroupName(int id)
        {
            return "match_" + id;
        }
        public override async Task OnConnectedAsync()
        {
            //Add user to dictionnary
            var userId = Context.UserIdentifier;
            //_userConnections[userId] = Context.ConnectionId!;
            await base.OnConnectedAsync();
        }



        public async Task UserPlaying()
        {

        }

        public async Task UserWatching()
        {

        }
        public async Task AfficheMatches() {
            Matches = await _context.Matches.Where(m => m.IsMatchCompleted == false).ToListAsync();
            await Clients.All.SendAsync("GetActiveMatches",Matches);


        }


       
    }
}
