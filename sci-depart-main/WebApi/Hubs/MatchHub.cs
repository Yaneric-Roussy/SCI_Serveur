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
    private static Dictionary<string, string> _userConnections = new();
    private string signalRId
    {
        get { return Context.ConnectionId!; }
    }
    private string userId
    {
        get { return Context.UserIdentifier!; }
    }

    public override async Task OnConnectedAsync()
    {
        //Add user to dictionnary
        var userId = Context.UserIdentifier; 
        _userConnections[userId] = Context.ConnectionId!;
        await base.OnConnectedAsync();
    }

    public async Task JoinMatch()
    {
        JoiningMatchData? joiningMatchData = await _matchesService.JoinMatch(userId,signalRId,null);
        if(joiningMatchData == null)
        {
            await Clients.Client(signalRId).SendAsync("JoiningMatchData", null);
        }
        else if(joiningMatchData != null)
        {
            if (joiningMatchData.OtherPlayerConnectionId != null)
            {
                await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("joiningMatchData", joiningMatchData);
            }
            await Clients.Client(signalRId).SendAsync("JoiningMatchData", joiningMatchData);
        }
    }


    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.UserIdentifier;
        _userConnections.Remove(userId);
        return base.OnDisconnectedAsync(exception); 
    }
}