using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType { get { return "PlayCard"; } }
        // TODO: Ajouter tout ce qui manque
        public int CardId { get; set; }
        public int Cost { get; set; }
        public int PlayerId { get; set; }
        public PlayCardEvent(MatchPlayerData currentPlayerData, PlayableCard playableCard)
        {
            currentPlayerData.Mana -= playableCard.Card.Cost;
            Cost = playableCard.Card.Cost;
            PlayerId = currentPlayerData.PlayerId;
            CardId = playableCard.Id;
            currentPlayerData.Hand.Remove(playableCard);
            playableCard.Index = currentPlayerData.BattleField.Count();
            currentPlayerData.BattleField.Add(playableCard);
        }
    }
}
