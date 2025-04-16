using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class ThornsEvent : MatchEvent
    {
        public override string EventType { get { return "ThornsEvent"; } }

        public ThornsEvent(MatchPlayerData currentPlayerData, PlayableCard card,PlayableCard ennemyCard)
        {
            this.Events = new List<MatchEvent>();

            this.Events.Add(new CardDamageEvent(currentPlayerData, ennemyCard, card));
        }
    }
}
