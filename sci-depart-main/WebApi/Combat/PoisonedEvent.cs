using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Combat
{
    public class PoisonedEvent : MatchEvent
    {
        public override string EventType { get { return "PoisonedEvent"; } }
        public int PlayerId { get; set; }
        public int CardId { get; set; }
        public List<PlayableCardStatus> PlayableCardsStatus { get; set; }
        public PoisonedEvent(MatchPlayerData currentPlayerData, PlayableCard playerCard)
        {
            this.Events = new List<MatchEvent>();

            int currentValue = playerCard.GetStatusValue(Status.POISONED_ID);

            if (currentValue > 0)
            {
                this.Events.Add(new CardDamageEvent(currentPlayerData, currentValue, playerCard));
                playerCard.AddStatusValue(Status.POISONED_ID, -1);
                int updatedValue = playerCard.GetStatusValue(Status.POISONED_ID);
                if (updatedValue <= 0)
                {
                    var pcs = playerCard.PlayableCardsStatus.FirstOrDefault(c => c.StatusId == Status.POISONED_ID);
                    if (pcs != null)
                    {
                        playerCard.PlayableCardsStatus.Remove(pcs);
                    }
                }
            }

            PlayerId = currentPlayerData.PlayerId;
            CardId = playerCard.Id;
            PlayableCardsStatus = playerCard.PlayableCardsStatus;
        }

    }
}
