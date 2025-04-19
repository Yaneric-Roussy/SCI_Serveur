using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardHealEvent : MatchEvent
    {
        public override string EventType { get { return "CardHeal"; } }
        public int PlayerId { get; set; }
        public int Heal { get; set; }
        public int CardInt { get; set; }
        public CardHealEvent(PlayableCard card, int amount)
        {
            //Vérifie que la carte est vivante
            if(card.Health > 0) {
                //On vérifie si la carte peux recevoir tout le heal
                if ((card.Card.Health - card.Health) >= amount)
                {
                    card.Health += amount;
                }
                else
                {
                    card.Health += (card.Card.Health - card.Health);
                }
            }
        }
    }
}
