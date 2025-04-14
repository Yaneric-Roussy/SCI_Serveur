using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType { get { return "PlayCard"; } }
        // TODO: Ajouter tout ce qui manque
        public int CardId { get; set; }
        public int PlayerId { get; set; }
        public PlayCardEvent(MatchPlayerData currentPlayerData, int playableCardId)
        {
            PlayerId = currentPlayerData.PlayerId;
            CardId = playableCardId;
            PlayableCard? card = currentPlayerData.Hand.Find(e => e.Id == playableCardId);
            if (card != null ) {
                currentPlayerData.Hand.Remove(card);
                currentPlayerData.BattleField.Add(card);
            }
        }
    }
}
