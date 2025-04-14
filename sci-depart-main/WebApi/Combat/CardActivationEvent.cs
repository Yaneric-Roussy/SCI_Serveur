using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardActivationEvent : MatchEvent
    {
        public override string EventType { get { return "CardActivation"; } }

        public CardActivationEvent(Match match, PlayableCard card, PlayableCard? ennemyCard, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {

            this.Events = new List<MatchEvent>();

            if (card.HasPower(Power.FIRST_STRIKE_ID))
            {
                this.Events.Add(new FirstStrikeEvent());
            }
            if(card.HasPower(Power.THORNS_ID)){
                this.Events.Add(new ThornsEvent());
            }
            if (card.HasPower(Power.HEAL_ID))
            {
                this.Events.Add(new HealEvent());
            }
            if (card.HasPower(4))
            {
                this.Events.Add(new FirstStrikeEvent());
            }

            this.Events.Add(new AttackEvent(match,ennemyCard, card, currentPlayerData,opposingPlayerData));

        }

    }
}
