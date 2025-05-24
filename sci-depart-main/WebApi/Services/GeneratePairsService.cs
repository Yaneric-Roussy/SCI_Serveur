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
    public class GeneratePairsService
    {
        public const int CONSTANTE = 6;
        public GeneratePairsService()
        {
        }

        public List<PairOfPlayers> GeneratePairs(List<PlayerInfo> playerInfos)
        {
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
    }
}
