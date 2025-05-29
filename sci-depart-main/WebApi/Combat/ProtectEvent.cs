using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Combat
{
    public class ProtectEvent : MatchEvent
    {
        public override string EventType { get { return "ProtectEvent"; } }
        public int Duration { get; set; }
        public int PlayerId { get; set; }
        public MatchPlayerData PlayerData { get; set; }
        public ProtectEvent(MatchPlayerData currentPlayerData, PlayableCard playerCard)
        {
            this.Events = new List<MatchEvent>();

            int value;
            if (playerCard.HasStatus(Power.PROTECTION_ID))
            {
                value = playerCard.GetStatusValue(Power.PROTECTION_ID);
            }
            else
            {
                value = playerCard.GetPowerValue(Power.PROTECTION_ID);
            }


            playerCard.AddStatusValue(Status.PROTECTED_ID, value);

            var pcs = playerCard.PlayableCardsStatus.First(c => c.StatusId == Status.PROTECTED_ID);
            if (pcs.Status == null)
            {
                pcs.Status = GameStatuses.Protected;
            }

            Duration = value;
            PlayerId = currentPlayerData.PlayerId;
            PlayerData = currentPlayerData;
        }
    }
}
