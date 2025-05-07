using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [ValidateNever]
        public virtual List<PlayableCardStatus> PlayableCardStatus { get; set; }

        public bool HasStatus(int powerId)
        {
            throw new NotImplementedException();
        }

        public void AddStatusValue(int powerId)
        {
            throw new NotImplementedException();
        }

        public int GetStatusValue(int powerId)
        {
            throw new NotImplementedException();
        }

        public bool HasPower(int powerId)
        {
            if(Card.CardPowers == null)
            {
                return false;
            }
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

