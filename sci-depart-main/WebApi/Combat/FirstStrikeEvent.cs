using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class FirstStrikeEvent : MatchEvent
    {
        public override string EventType { get { return "FirstStrike"; } }

        public FirstStrikeEvent(MatchPlayerData currentPlayerData, PlayableCard card, PlayableCard ennemyCard, MatchPlayerData oppPlayerData)
        {
            this.Events = new List<MatchEvent>();

            this.Events.Add(new CardDamageEvent(currentPlayerData, card, ennemyCard));
            if(ennemyCard.Health > 0)
            {
                this.Events.Add(new CardDamageEvent(oppPlayerData, card, ennemyCard));
            }
        }
    }
}
