using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Client;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Hubs;

//[Authorize]
public class MatchHub : Hub
{
    ApplicationDbContext _context;
    MatchesService _matchesService;
    public MatchHub(ApplicationDbContext context, MatchesService matchesService)
    {
        _context = context;
        _matchesService = matchesService;
    }
    private string userSignalRId
    {
        get { return Context.ConnectionId!; }
    }

    private string groupName(int matchId)
    {
        return "Match_" + matchId.ToString();
    }

    public override async Task OnConnectedAsync()
    {
        //Console.WriteLine($"User Connected: {Context.UserIdentifier}, Connection ID: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    public async Task JoinMatch(string userId, string? connectionId, int? specificMatchId)
    {
        JoiningMatchData? joiningMatchData = await _matchesService.JoinMatch(userId, connectionId, specificMatchId);

        if(joiningMatchData != null)
        {
            await Clients.Client(userSignalRId).SendAsync("JoiningMatchData", joiningMatchData);
        }
        else
        {
            await Clients.Client(userSignalRId).SendAsync("LookingForOtherPlayer", "Waiting on another player for match.");
        }
    }

    public async Task StartMatch(Match match)
    {
        var startMatchEvent = await _matchesService.StartMatch(userSignalRId, match);
        await Groups.AddToGroupAsync(userSignalRId, groupName(match.Id));
        await Clients.Client(userSignalRId).SendAsync("StartMatchInfo", startMatchEvent);
    }

    public async Task EndTurn(string userId, int matchId)
    {
        var playerEndTurnEvent = await _matchesService.EndTurn(userId, matchId);
        await Clients.Group(groupName(matchId)).SendAsync("PlayerEndTurn", playerEndTurnEvent);
    }
}