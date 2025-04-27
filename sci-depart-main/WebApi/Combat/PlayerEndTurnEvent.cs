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

            //Order by pour s'assurer de l'ordre des cartes.
            currentPlayerData.BattleField.OrderBy(c => c.Index);
            opposingPlayerData.BattleField.OrderBy(c => c.Index);

            var opBattlefield = opposingPlayerData.BattleField;
            for (int i = currentPlayerData.BattleField.Count() - 1; i >= 0; i--)
            {
                PlayableCard card = currentPlayerData.BattleField[i];
                PlayableCard? ennemyCard = opposingPlayerData.BattleField.ElementAtOrDefault(i);
                this.Events.Add(new CardActivationEvent(match, card,ennemyCard,currentPlayerData,opposingPlayerData));
            }
            
            this.Events.Add(new PlayerStartTurnEvent(opposingPlayerData, nbManaPerTurn));
        }

    }
}
