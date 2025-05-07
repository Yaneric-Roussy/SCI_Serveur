using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Hubs;
using System.Threading.Channels;

namespace WebApi.Services
{
    public class MatchmakingService : BackgroundService
    {
        public const int DELAY = 30 * 1000;
        public IServiceScopeFactory _serviceScopeFactory;
        public IHubContext<MatchHub> _matchHub;
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

                //faire des actions.
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
