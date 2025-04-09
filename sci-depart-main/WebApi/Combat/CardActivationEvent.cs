using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CardActivationEvent : MatchEvent
    {
        public override string EventType { get { return "CardActivation"; } }

        public CardActivationEvent(PlayableCard card, PlayableCard? ennemyCard, int cardPos)
        {

            this.Events = new List<MatchEvent>();

            if (card.HasPower(Power.FIRST_STRIKE_ID))
            {
                this.Events.Add(new FirstStrikeEvent());
            }
            else if(card.HasPower(Power.THORNS_ID)){
                this.Events.Add(new ThornsEvent());
            }
            else if (card.HasPower(Power.HEAL_ID))
            {
                this.Events.Add(new HealEvent());
            }
            else
            {
                this.Events.Add(new FirstStrikeEvent());

            }

            this.Events.Add(new AttackEvent(ennemyCard, card.Attack,cardPos));

        }

    }
}
