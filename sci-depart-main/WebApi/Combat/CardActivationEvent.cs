using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardActivationEvent : MatchEvent
    {
        public override string EventType { get { return "CardActivation"; } }
        public int CardId { get; set; }
        public List<int> PowerIds { get; set; }
        public CardActivationEvent(Match match, PlayableCard card, PlayableCard? ennemyCard, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {

            this.Events = new List<MatchEvent>();
            this.CardId = card.Id;
            this.PowerIds = new List<int>();

            if (card.HasStatus(Status.STUNNED_ID))
            {

            }
            if (card.HasStatus(Status.POISONED_ID))
            {
                this.Events.Add(new PoisonedEvent(currentPlayerData, card));
            }
            if (card.HasPower(Power.ATTACK_BOOST_ID))
            {
                PowerIds.Add(Power.ATTACK_BOOST_ID);
                card.Attack += card.GetPowerValue(Power.ATTACK_BOOST_ID);
                this.Events.Add(new DamageBoostEvent(currentPlayerData, card));
            }
            if (card.HasPower(Power.HEAL_ID))
            {
                PowerIds.Add(Power.HEAL_ID);
                this.Events.Add(new HealEvent(currentPlayerData, card));
            }
            if(ennemyCard != null) {
                if (ennemyCard.HasPower(Power.THORNS_ID))
                {
                    this.Events.Add(new ThornsEvent(currentPlayerData, card, ennemyCard));
                }
                if (card.HasPower(Power.FIRST_STRIKE_ID))
                {
                    PowerIds.Add(Power.FIRST_STRIKE_ID);
                    this.Events.Add(new FirstStrikeEvent(currentPlayerData, card, ennemyCard, opposingPlayerData));
                    //if (opposingPlayerData.BattleField.Contains(ennemyCard))
                    //{
                    //    this.Events.Add(new CardDamageEvent(currentPlayerData, ennemyCard.Attack, card));
                    //}
                }
                if (card.HasPower(Power.POISON_ID))
                {
                    Events.Add(new PoisonEvent(currentPlayerData, opposingPlayerData, card, ennemyCard));
                }
                if (card.HasPower(Power.STUNNED_ID))
                {
                    //Getting there...
                }
            }
            if ((!card.HasPower(Power.FIRST_STRIKE_ID) || ennemyCard == null) && currentPlayerData.BattleField.Contains(card))
            {
                this.Events.Add(new AttackEvent(match, ennemyCard, card, currentPlayerData, opposingPlayerData));
            }
            if (card.HasPower(Power.ATTACK_BOOST_ID))
            {
                card.Attack -= card.GetPowerValue(Power.ATTACK_BOOST_ID);
            }
            if (card.HasPower(Power.CHAOS_ID))
            {
                Events.Add(new ChaosEvent(currentPlayerData, opposingPlayerData));
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
