using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace Super_Cartes_Infinies.Hubs;

[Authorize]
public class MatchHub : Hub
{
    ApplicationDbContext _context;
    MatchesService _matchesService;
    List<Match> Matches = new List<Match>();

    public MatchHub(ApplicationDbContext context, MatchesService matchesService)
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

    public async Task RegarderPartie(int matchId)
    {
        JoiningMatchData? joiningMatchData = await _matchesService.JoinMatchSpectator(userId, matchId);
        string groupName = WriteGroupName(matchId);
        await Groups.AddToGroupAsync(signalRId, groupName);
        await Clients.Client(signalRId).SendAsync("JoiningMatchSpectator", joiningMatchData);
        await Clients.Group(groupName).SendAsync("test", "SPECTATEUR AREGR");
    }
    public async Task JoinMatch()

    public async Task JoinMatch(bool fisrt)

    {
        JoiningMatchData? joiningMatchData = await _matchesService.JoinMatch(userId, signalRId, null, fisrt);
        if (joiningMatchData == null)
        {
            await Clients.Client(signalRId).SendAsync("JoiningMatchData", null);
        }
        else if (joiningMatchData != null)
        {
            string groupName = WriteGroupName(joiningMatchData.Match.Id);
            await Groups.AddToGroupAsync(signalRId, groupName);
            await Clients.User(userId).SendAsync("joiningMatchData", joiningMatchData);
            if (joiningMatchData.IsStarted == false)
            {
                //Ajout l'autre utilisateur au groupe puisque le match vient juste de commencer.
                //--------------------
                //--Ancienne méthode--
                //--------------------
                //await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName);
                //await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("joiningMatchData", joiningMatchData);
                if (userId == joiningMatchData.PlayerB.UserId)
                {
                    await Groups.AddToGroupAsync(joiningMatchData.PlayerA.UserId, groupName);
                    joiningMatchData.IsStarted = true;
                    await Clients.User(joiningMatchData.PlayerA.UserId).SendAsync("joiningMatchData", joiningMatchData);
                }
                else
                {
                    await Groups.AddToGroupAsync(joiningMatchData.PlayerB.UserId, groupName);
                    joiningMatchData.IsStarted = true;
                    await Clients.User(joiningMatchData.PlayerB.UserId).SendAsync("joiningMatchData", joiningMatchData);
                }


                //await Clients.Users()
            }
            //Cette partie s'active tjrs et dois ajouter le user au groupe pour que s'il essaye de rejoin il fait tjrs partie du groupe.
            //Add both users to a group. Should happen every reload and at the start of the game

        }
    }
    public async Task StopSearch()
    {
        PlayerInfo? pi = await _context.PlayerInfos.Where(p => p.UserId == userId).SingleOrDefaultAsync();
        if(pi != null)
        {
            pi.Attente = null;
            await _context.SaveChangesAsync();
        }

    }
    public async Task StartMatchEvent(Match match)
    {
        StartMatchEvent startMatchEvent = await _matchesService.StartMatch(userId, match.Id);
        string groupName = WriteGroupName(match.Id);
        await Clients.Group(groupName).SendAsync("ApplyEvents", startMatchEvent);
        

    }
    public async Task PlayCard(Match match,int cardInt )
    {
        
        PlayCardEvent playCardEvent = await _matchesService.PlayCard(userId, match.Id, cardInt);
        string groupName = WriteGroupName(match.Id);
        await Clients.Group(groupName).SendAsync("PlayCard", playCardEvent);
    }
    public async Task EndTurn(int matchId)
    {
        PlayerEndTurnEvent endTurnEvent = await _matchesService.EndTurn(userId, matchId);
        string groupName = WriteGroupName(matchId);
        await Clients.Group(groupName).SendAsync("PlayerEndedTurn", endTurnEvent);
    }

    public async Task Surrender(int matchId)
    {
        SurrenderEvent playerSurrenderEvent = await _matchesService.Surrender(userId, matchId);
        string groupName = WriteGroupName(matchId);
        await Clients.Group(groupName).SendAsync("PlayerSurrendered", playerSurrenderEvent);
    }


    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.UserIdentifier;
        //_userConnections.Remove(userId);
        return base.OnDisconnectedAsync(exception); 
    }
    public async Task AfficheMatches()
    {
        Matches = await _context.Matches.Where(m => m.IsMatchCompleted == false).ToListAsync();
        await Clients.All.SendAsync("GetActiveMatches", Matches);


    }
    public async Task sendmessage(string message, int matchid,string user)
    {
        string groupName = $"match_{matchid}";
        
        await Clients.Group(groupName).SendAsync("ReceiveChatMessage",message,user);
    }

}