using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class DamageBoostEvent : MatchEvent
    {
        public override string EventType { get { return "DamageBoostEvent"; } }
        public int PlayerId { get; set; }
        public int CardInt { get; set; }

        public DamageBoostEvent(MatchPlayerData currentPlayerData, PlayableCard card)
        {
            PlayerId = currentPlayerData.PlayerId;
            CardInt = card.Id;
        }
    }
}
