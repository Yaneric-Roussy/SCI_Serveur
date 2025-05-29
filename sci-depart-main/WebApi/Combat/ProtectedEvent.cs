using Microsoft.Extensions.Logging;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System.Runtime;

namespace WebApi.Combat
{
    public class ProtectedEvent : MatchEvent
    {
        public override string EventType { get { return "ProtectedEvent"; } }
        public int PlayerId { get; set; }
        public int CardId { get; set; }
        public List<PlayableCardStatus> PlayableCardsStatus { get; set; }
        public ProtectedEvent(MatchPlayerData currentPlayerData, PlayableCard playerCard)
        {
            this.Events = new List<MatchEvent>();

            playerCard.AddStatusValue(Status.PROTECTED_ID, -1);

            int updatedValue = playerCard.GetStatusValue(Status.PROTECTED_ID);
            if (updatedValue <= 0)
            {
                var pcs = playerCard.PlayableCardsStatus.FirstOrDefault(c => c.StatusId == Status.PROTECTED_ID);
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
