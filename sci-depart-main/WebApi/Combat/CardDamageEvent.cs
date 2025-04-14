using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDamageEvent : MatchEvent
    {
        public override string EventType { get { return "CardDamage"; } }

        public int PlayerId { get; set; }
        public int Dps { get; set; }
        public int CardInt { get; set; }

        public CardDamageEvent(MatchPlayerData PlayerData, PlayableCard card)
        {

            this.Events = new List<MatchEvent>();

            PlayerId = PlayerData.PlayerId ;
            Dps = card.Attack;
            CardInt = card.Id;

            card.Health -= card.Attack;
            
            if (card.Health <= 0)
            {
                Events.Add(new CardDeathEvent(PlayerData,card));
            }

        }
    }
}
