using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Combat
{
    public class StunnedEvent : MatchEvent
    {
        public override string EventType { get { return "StunnedEvent"; } }
        public int PlayerId { get; set; }
        public int CardId { get; set; }
        public List<PlayableCardStatus> PlayableCardsStatus { get; set; }
        public StunnedEvent(MatchPlayerData currentPlayerData, PlayableCard playerCard)
        {
            this.Events = new List<MatchEvent>();

            playerCard.AddStatusValue(Status.STUNNED_ID, -1);

            int updatedValue = playerCard.GetStatusValue(Status.STUNNED_ID);
            if (updatedValue <= 0)
            {
                var pcs = playerCard.PlayableCardsStatus.FirstOrDefault(c => c.StatusId == Status.STUNNED_ID);
                if (pcs != null)
                {
                    playerCard.PlayableCardsStatus.Remove(pcs);
                }
            }

            PlayerId = currentPlayerData.PlayerId;
            CardId = playerCard.Id;
            PlayableCardsStatus = playerCard.PlayableCardsStatus;
        }
    }
}
