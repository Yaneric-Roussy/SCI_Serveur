using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
        public virtual List<PlayableCardStatus> PlayableCardsStatus { get; set; }

        public bool HasStatus(PlayableCard pc, int statusId)
        {
            if(pc.PlayableCardsStatus == null)
            {
                return false;
            }

            foreach(PlayableCardStatus pcs in pc.PlayableCardsStatus)
            {
                if(pcs.StatusId == statusId || pcs.Status.Id == statusId)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddStatusValue(PlayableCard pc, int powerId, Status status)
        {
            int powerValue = GetPowerValue(powerId);
            PlayableCardStatus pcs = new PlayableCardStatus()
            {
                Value = powerValue,
                StatusId = status.Id,
                Status = status
            };
            pc.PlayableCardsStatus.Add(pcs);
        }

        public int GetStatusValue(PlayableCard pc, int statusId)
        {
            if (HasStatus(pc, statusId))
            {
                PlayableCardStatus pcs = pc.PlayableCardsStatus.Find(c => c.Status.Id == statusId)!;
                return pcs.Value;
            }
            else
            {
                return 0;
            }
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

