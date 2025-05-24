using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.ComponentModel;

namespace Super_Cartes_Infinies.Hubs;

[Authorize]
public class MatchHub : Hub
{
    ApplicationDbContext _context;
    MatchesService _matchesService;
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

    public async Task JoinMatch(bool fisrt)
    {
        JoiningMatchData? joiningMatchData = await _matchesService.JoinMatch(userId,signalRId,null, fisrt);
        if(joiningMatchData == null)
        {
            await Clients.Client(signalRId).SendAsync("JoiningMatchData", null);
        }
        else if(joiningMatchData != null)
        {
            string groupName = WriteGroupName(joiningMatchData.Match.Id);
            await Groups.AddToGroupAsync(signalRId, groupName);
            await Clients.Client(signalRId).SendAsync("JoiningMatchData", joiningMatchData);
            if (joiningMatchData.IsStarted == false)
            {
                //Ajout l'autre utilisateur au groupe puisque le match vient juste de commencer.
                //--------------------
                //--Ancienne méthode--
                //--------------------
                //await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName);
                //await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("joiningMatchData", joiningMatchData);

                await Groups.AddToGroupAsync(joiningMatchData.PlayerB.UserId, groupName);
                joiningMatchData.IsStarted = true;
                await Clients.User(joiningMatchData.PlayerB.UserId).SendAsync("joiningMatchData", joiningMatchData);

                //await Clients.Users()
            }
            //Cette partie s'active tjrs et dois ajouter le user au groupe pour que s'il essaye de rejoin il fait tjrs partie du groupe.
            //Add both users to a group. Should happen every reload and at the start of the game

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
}