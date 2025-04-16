using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
	public class PlayableCard : IModel
    {
		public PlayableCard()
		{
		}

        public PlayableCard(Card c)
        {
			Card = c;
            Health = c.Health;
            Attack = c.Attack;
        }

        public int Id { get; set; }
		public virtual Card Card { get; set; }
		public int Health { get; set; }
        public int Attack { get; set; }
        public int Index { get; set; }

        public bool HasPower(int powerId)
        {
            foreach(CardPower cardPower in Card.CardPowers)
            {
                if (cardPower.PowerId == powerId || cardPower.Power.Id == powerId)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetPowerValue(int powerId)
        {
            if (HasPower(powerId))
            {
                CardPower cardPower = Card.CardPowers.Find(c => c.Power.Id == powerId)!;
                return cardPower.Value;
            }
            else
            {
                return 0;
            }
        }
    }
}

