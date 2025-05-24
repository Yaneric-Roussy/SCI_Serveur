using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Services;
using Super_Cartes_Infinies.Data;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Tests.Services
{
    [TestClass()]
    public class GeneratePairsServiceTest

    {
        [TestInitialize]
        public void Init()
        {
            
        }
        [TestCleanup]
        public void Dispose()
        {
        }

        [TestMethod()]
        public void EloProches()
        {
            GeneratePairsService generatePairsService = new GeneratePairsService();
            List<PlayerInfo> playerInfos = new List<PlayerInfo>();
            playerInfos.Add(new PlayerInfo
            {
                Attente = 5,
                Elo = 1010,

            });
            playerInfos.Add(new PlayerInfo
            {
                Attente = 0,
                Elo = 990
            });
            List<PairOfPlayers> pairOfPlayers = generatePairsService.GeneratePairs(playerInfos);
           

            Assert.AreEqual(pairOfPlayers.Count(), 1);
        }

       
        [TestMethod()]
        public void EloLoin()
        {
            GeneratePairsService generatePairsService = new GeneratePairsService();
            List<PlayerInfo> playerInfos = new List<PlayerInfo>();
            playerInfos.Add(new PlayerInfo
            {
                Attente = 0,
                Elo = 1500,

            });
            playerInfos.Add(new PlayerInfo
            {
                Attente = 0,
                Elo = 769
            });
            List<PairOfPlayers> pairOfPlayers = generatePairsService.GeneratePairs(playerInfos);


            Assert.AreEqual(pairOfPlayers.Count(), 0);

        }
        [TestMethod]
        public void TroisPaires()
        {
            GeneratePairsService generatePairsService = new GeneratePairsService();
            List<PlayerInfo> playerInfos = new List<PlayerInfo>();
            PlayerInfo tropLoin1 = new PlayerInfo
            {
                Attente = 0,
                Elo = 2200,

            };
            PlayerInfo tropLoin2 = new PlayerInfo
            {
                Attente = 20,
                Elo = 169
            }; 
            PlayerInfo proche1_1 = new PlayerInfo
            {
                Attente = 20,
                Elo = 611
            }; 
            PlayerInfo proche1_2 = new PlayerInfo
            {
                Attente = 10,
                Elo = 510
            }; 
            PlayerInfo proche2_1 = new PlayerInfo
            {
                Attente = 6,
                Elo = 1301
            };
            PlayerInfo proche2_2 = new PlayerInfo
            {
                Attente = 7,
                Elo = 1340
            };

            playerInfos.Add(tropLoin1);
            playerInfos.Add(proche1_1);
            playerInfos.Add(proche2_2);
            playerInfos.Add(tropLoin2);
            playerInfos.Add(proche2_1);
            playerInfos.Add(proche1_2);
            List<PairOfPlayers> pairOfPlayers = generatePairsService.GeneratePairs(playerInfos);


            Assert.AreEqual(pairOfPlayers.Count(), 2);
        }
    }
}