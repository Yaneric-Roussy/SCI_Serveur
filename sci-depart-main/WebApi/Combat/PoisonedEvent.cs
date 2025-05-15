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
        public List<PlayableCardStatus> PlayableCardStatus { get; set; }
        public PoisonedEvent(MatchPlayerData currentPlayerData, PlayableCard playerCard)
        {
            this.Events = new List<MatchEvent>();
            int value = playerCard.GetStatusValue(Status.POISONED_ID);

            if (value > 0)
            {
                //On cause du dégât et on réduit de un la durée
                this.Events.Add(new CardDamageEvent(currentPlayerData, value, playerCard));
                playerCard.AddStatusValue(Status.POISONED_ID, -1);
            }
            if ((value - 1) <= 0)
            {
                //On enlève le pcs parce que l'effet est fini.
                var pcs = playerCard.PlayableCardsStatus.First(c => c.StatusId == Status.POISONED_ID);
                playerCard.PlayableCardsStatus.Remove(pcs);
            }

            PlayerId = currentPlayerData.PlayerId;
            CardId = playerCard.Id;
            PlayableCardStatus = playerCard.PlayableCardsStatus;
        }
    }
}
