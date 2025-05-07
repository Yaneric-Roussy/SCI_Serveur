using Microsoft.Extensions.Logging;
using Models.Models;
using Super_Cartes_Infinies.Models;

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
            string userId;

            if (match.PlayerDataA.PlayerId == winningPlayerData.PlayerId)
                userId = match.UserAId;
            else
                userId = match.UserBId;
           
            victoiredéfaite(losingPlayerData, winningPlayerData);
           
          


            match.WinnerUserId = userId;
        }

        void victoiredéfaite(MatchPlayerData perdant, MatchPlayerData gagnant)
        {
            perdant.Player.Defaite++;
            perdant.Player.listeDeck.Where(i => i.Courant).First().Defaite++;
            gagnant.Player.Victoire++;
            gagnant.Player.listeDeck.Where(i => i.Courant).First().Victoire++;
        }
    }
}
