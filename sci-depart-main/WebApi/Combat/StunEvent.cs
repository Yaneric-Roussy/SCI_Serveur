using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Combat
{
    public class StunEvent : MatchEvent
    {
        public override string EventType { get { return "StunEvent"; } }
        public int Duration { get; set; }
        public int PlayerId { get; set; }
        public MatchPlayerData OpposingPlayerData { get; set; }
        public StunEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, PlayableCard playerCard, PlayableCard ennemyCard)
        {
            this.Events = new List<MatchEvent>();
            int value;
            if (playerCard.HasStatus(Power.STUNNED_ID))
            {
                value = playerCard.GetStatusValue(Power.STUNNED_ID);
            }
            else
            {
                value = playerCard.GetPowerValue(Power.STUNNED_ID);
            }


            //opposingPlayerData.BattleField.FirstOrDefault(c => c.Id == ennemyCard.Id).AddStatusValue(Status.POISONED_ID, value);
            ennemyCard.AddStatusValue(Status.STUNNED_ID, value);

            var pcs = ennemyCard.PlayableCardsStatus.First(c => c.StatusId == Status.STUNNED_ID);
            if (pcs.Status == null)
            {
                pcs.Status = GameStatuses.Stunned;
            }

            Duration = value;
            PlayerId = opposingPlayerData.PlayerId;
            OpposingPlayerData = opposingPlayerData;
        }
    }
}
