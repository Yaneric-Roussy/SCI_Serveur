using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Models;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Hubs;
using System.Threading.Channels;
using Super_Cartes_Infinies.Services;

namespace WebApi.Services
{
    public class MatchmakingService : BackgroundService
    {
        public const int DELAY = 1 * 1000;
        public IServiceScopeFactory _serviceScopeFactory;
        public IHubContext<MatchHub> _matchHub;
        public MatchesService _matchService;
        public MatchmakingService(IHubContext<MatchHub> matchHub, IServiceScopeFactory serviceScopeFactory)
        {
            _matchHub = matchHub;
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task DoSomething(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                List<PlayerInfo> playerInfos = await dbContext.PlayerInfos.Where(p => p.Attente != null).ToListAsync();
                var copy = new List<PlayerInfo>(playerInfos);

                GeneratePairsService generatePairsService = scope.ServiceProvider.GetRequiredService<GeneratePairsService>();
                List<PairOfPlayers> pairs = generatePairsService.GeneratePairs(copy);
                //faire des actions.
                // Passer une COPIE de l'information sur les players (Car on va retirer les éléments de la liste, même si le player n'est pas mis dans une paire)
                
                var playersWithAttente = await dbContext.PlayerInfos.Where(p => p.Attente != null).ToListAsync();
                foreach (var player in playersWithAttente)
                {
                    player.Attente++;
                }
                await dbContext.SaveChangesAsync();
                foreach (PairOfPlayers pair in pairs)
                {
                    PlayerInfo p1 = await dbContext.PlayerInfos.Where(p => p.Id == pair.PlayerInfo1.Id).SingleAsync();
                    p1.Attente = null;
                    PlayerInfo p2 = await dbContext.PlayerInfos.Where(p => p.Id == pair.PlayerInfo2.Id).SingleAsync();
                    p2.Attente = null;
                    playerInfos.Remove(pair.PlayerInfo1);
                    playerInfos.Remove(pair.PlayerInfo2);
                    await dbContext.SaveChangesAsync();
                    MatchesService matchesService = scope.ServiceProvider.GetRequiredService<MatchesService>();
                    await matchesService.PartMatch(pair);
                    await _matchHub.Clients.User(pair.PlayerInfo1.UserId).SendAsync("FoundMatch", pair.PlayerInfo1.UserId);
                }
                
            }

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(DELAY, stoppingToken);
                await DoSomething(stoppingToken);
            }
        }
    }
}
