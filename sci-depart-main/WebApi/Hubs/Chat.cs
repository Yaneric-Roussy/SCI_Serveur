using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.Reflection;


namespace WebApi.Hubs
{
    public class Chat : Hub
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
        public async Task AfficheMatches()
        {
            Matches = await _context.Matches.Where(m => m.IsMatchCompleted == false).ToListAsync();
            await Clients.All.SendAsync("GetActiveMatches", Matches);


        }
        public async Task regarderPartie(string PlayerId,int matchid)
        {
            JoiningMatchData? joiningMatchData = await _matchesService.JoinMatch(PlayerId, signalRId, matchid);
   
            if (joiningMatchData == null)
            {
                await Clients.Client(signalRId).SendAsync("JoiningMatchData", null);
            }
            else if (joiningMatchData != null)
            {
                string groupName = WriteGroupName(joiningMatchData.Match.Id);
                if (joiningMatchData.OtherPlayerConnectionId != null)
                {
                    //Ajout l'autre utilisateur au groupe puisque le match vient juste de commencer.
                    await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName);
                    await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("joiningMatchData", joiningMatchData);
                }
                //Cette partie s'active tjrs et dois ajouter le user au groupe pour que s'il essaye de rejoin il fait tjrs partie du groupe.
                //Add both users to a group. Should happen every reload and at the start of the game
                await Groups.AddToGroupAsync(signalRId, groupName);
                await Clients.Client(signalRId).SendAsync("JoiningMatchData", joiningMatchData);
            }
        }
       

    }
}
