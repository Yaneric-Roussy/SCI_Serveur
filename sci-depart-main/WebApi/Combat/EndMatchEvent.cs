using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Models;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Combat
{
    public class EndMatchEvent : MatchEvent
    {
        public override string EventType { get { return "EndMatch"; } }
        public int WinningPlayerId { get; set; }
        public int MoneyReceivedByWinner { get { return 10; }} 
        public int MoneyReceivedByLoser { get { return 2; } }

        public EndMatchEvent(Match match, MatchPlayerData winningPlayerData, MatchPlayerData losingPlayerData)
        {
            // Pour l'instant, on n'arrête pas la simulation sur le serveur lorsqu'on atteint la fin de la partie.
            // Pour éviter qu'un joueur qui a gagné, mais qui meurt dans le même tour ne donne la victoire à l'autre, on vérifie si le match est déjà terminé!
            if (match.IsMatchCompleted)
                return;
            
                
            //if(winningPlayerData.PlayerId != 0) 
            WinningPlayerId = winningPlayerData.PlayerId;

            match.IsMatchCompleted = true;
            winningPlayerData.Player.Money += MoneyReceivedByWinner;
            losingPlayerData.Player.Money += MoneyReceivedByLoser;

            //Change the elo of players
            if(winningPlayerData.Player.playerInfo !=null && losingPlayerData.Player.playerInfo != null)
            {
                int winnerElo = winningPlayerData.Player.playerInfo.Elo;
                int loserElo = losingPlayerData.Player.playerInfo.Elo;
                EloCalculator.CalculateELO(ref winnerElo, ref loserElo, EloCalculator.GameOutcome.Win);
                winningPlayerData.Player.playerInfo.Elo = winnerElo;
                losingPlayerData.Player.playerInfo.Elo = loserElo;
            }

            string userId;
            if (match.PlayerDataA.PlayerId == winningPlayerData.PlayerId)
                userId = match.UserAId;

            else
                userId = match.UserBId;

            match.WinnerUserId = userId;
        }
    }
}
