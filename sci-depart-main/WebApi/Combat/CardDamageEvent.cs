using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDamageEvent : MatchEvent
    {
        public override string EventType { get { return "CardDamage"; } }

        public int PlayerId { get; set; }
        public int Dps { get; set; }
        public int CardInt { get; set; }

        public CardDamageEvent(MatchPlayerData PlayerData, PlayableCard cardAttacking, PlayableCard cardDefending )
        {

            this.Events = new List<MatchEvent>();

            PlayerId = PlayerData.PlayerId ;
            Dps = cardAttacking.Attack;
            CardInt = cardDefending.Id;

            cardDefending.Health -= cardAttacking.Attack;
            
            if (cardDefending.Health <= 0)
            {
                Events.Add(new CardDeathEvent(PlayerData, cardDefending));
            }

        }
    }
}
