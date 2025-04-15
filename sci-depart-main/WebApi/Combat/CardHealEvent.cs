using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardHealEvent : MatchEvent
    {
        public override string EventType { get { return "CardHeal"; } }

        public CardHealEvent(PlayableCard card, int amount)
        {
            //Vérifie que la carte est vivante
            if(card.Health > 0) {
                //On vérifie si la carte peux recevoir tout le heal
                if ((card.Card.Health - card.Health) < amount)
                {
                    card.Health += (card.Card.Health - card.Health);
                }
                else
                {
                    card.Health += amount;
                }
            }
        }
    }
}
