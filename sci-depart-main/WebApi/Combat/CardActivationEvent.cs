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

            if (card.HasPower(Power.HEAL_ID))
            {
                this.Events.Add(new HealEvent(currentPlayerData, card));
            }
            if (ennemyCard != null && ennemyCard.HasPower(Power.THORNS_ID))
            {
                this.Events.Add(new ThornsEvent(currentPlayerData, card, ennemyCard));
            }
            if (card.HasPower(Power.FIRST_STRIKE_ID))
            {
                this.Events.Add(new FirstStrikeEvent());
            }
            
            
            if (card.HasPower(4))
            {
                this.Events.Add(new FirstStrikeEvent());
            }
            if (!card.HasPower(Power.FIRST_STRIKE_ID))
            {
                this.Events.Add(new AttackEvent(match, ennemyCard, card, currentPlayerData, opposingPlayerData));
            }
            
            //if (ennemyCard == null)
            //{
            //    //Pas de cartes ennemy
            //    //Est-ce que devrait créer direct l'event de playerdamage?
            //    this.Events.Add(new AttackEvent(match, ennemyCard, card, currentPlayerData, opposingPlayerData));
            //}
            //else
            //{
            //    //Les deux cartes s'attaquent
            //    this.Events.Add(new AttackEvent(match, ennemyCard, card, currentPlayerData, opposingPlayerData));
            //    this.Events.Add(new AttackEvent(match, card, ennemyCard, currentPlayerData, opposingPlayerData));
            //}
            

        }

    }
}
