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
            PlayableCardsStatus = new List<PlayableCardStatus>();
        }

        public int Id { get; set; }
		public virtual Card Card { get; set; }
		public int Health { get; set; }
        public int Attack { get; set; }
        public int Index { get; set; }
        [ValidateNever]
        public virtual List<PlayableCardStatus> PlayableCardsStatus { get; set; } = new List<PlayableCardStatus>();

        public bool HasStatus(int statusId)
        {
            return PlayableCardsStatus?.Any(pcs => pcs.StatusId == statusId || pcs.Status?.Id == statusId) ?? false;
        }

        public void AddStatusValue(int statusId, int value)
        {
            var existingStatus = PlayableCardsStatus.FirstOrDefault(pcs => pcs.StatusId == statusId || pcs.Status?.Id == statusId);
            if(existingStatus != null && statusId == Status.POISONED_ID)
            {
                existingStatus.Value += value;
            }
            if (existingStatus == null)
            {
                PlayableCardsStatus.Add(new PlayableCardStatus
                {
                    Value = value,
                    StatusId = statusId
                });
            }
        }
        public int GetStatusValue(int statusId)
        {
            var status = PlayableCardsStatus.FirstOrDefault(pcs => pcs.StatusId == statusId || pcs.Status?.Id == statusId);
            return status?.Value ?? 0;
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

