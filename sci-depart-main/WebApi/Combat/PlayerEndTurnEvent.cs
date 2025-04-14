using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerEndTurnEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerEndTurn"; } }
        public int PlayerId { get; set; }
        // L'évènement lorsqu'un joueur termine son tour
        public PlayerEndTurnEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int nbManaPerTurn)
        {
            this.PlayerId = currentPlayerData.PlayerId;
            this.Events = new List<MatchEvent>();

            match.IsPlayerATurn = !match.IsPlayerATurn;
            
            for (int i = currentPlayerData.BattleField.Count(); i > 0; i--)
            {
                PlayableCard card = currentPlayerData.BattleField[i];
                PlayableCard? ennemyCard = opposingPlayerData.BattleField[i];
                this.Events.Add(new CardActivationEvent(match, card,ennemyCard,currentPlayerData,opposingPlayerData));
            }

            this.Events.Add(new PlayerStartTurnEvent(match,opposingPlayerData, nbManaPerTurn));
        }

    }
}
