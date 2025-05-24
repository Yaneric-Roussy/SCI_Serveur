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
                List<PairOfPlayers> pairs = GeneratePairs(copy);
                //faire des actions.
                // Passer une COPIE de l'information sur les players (Car on va retirer les éléments de la liste, même si le player n'est pas mis dans une paire)
                List<PairOfPlayers> GeneratePairs(List<PlayerInfo> playerInfos)
                {
                    const int CONSTANTE = 10;
                    List<PairOfPlayers> pairs = new List<PairOfPlayers>();
                
                    // Tant qu'il y a des joueurs à mettre en pair
                    while (playerInfos.Count > 0)
                    {
                        
                        PlayerInfo playerInfo = playerInfos[0];
                        playerInfos.RemoveAt(0);
                        int smallestELODifference = int.MaxValue;
                        int index = -1;
                        for (int i = 0; i < playerInfos.Count; i++)
                        {
                            PlayerInfo pi = playerInfos[i];
                            int difference = Math.Abs(pi.Elo - playerInfo.Elo);
                            //Accepter de plus en plus en fonction de l'attente
                            if (difference <= playerInfo.Attente * CONSTANTE)
                            {
                                if (difference < smallestELODifference)
                                {
                                    smallestELODifference = difference;
                                    index = i;
                                }
                            }
                        }
                        // Si on a trouvé une paire
                        if (index >= 0)
                        {
                            PlayerInfo playerInfo2 = playerInfos[index];
                            playerInfos.RemoveAt(index);
                            pairs.Add(new PairOfPlayers(playerInfo, playerInfo2));
                            // Sinon, c'est pas grave, on a retiré l'élément de la liste et on va évaluer le prochain
                        }
                    }
                    return pairs;
                }
                
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
