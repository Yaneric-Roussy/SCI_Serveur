using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Combat
{
    public class PoisonEvent : MatchEvent
    {
        public override string EventType { get { return "PoisonEvent"; } }
        public int Duration { get; set; }
        public int PlayerId { get; set; }
        public MatchPlayerData OpposingPlayerData { get; set; }
        public PoisonEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, PlayableCard playerCard, PlayableCard ennemyCard)
        {
            this.Events = new List<MatchEvent>();
            int value;
            if (playerCard.HasStatus(Power.POISON_ID))
            {
                value = playerCard.GetStatusValue(Power.POISON_ID);
            }
            else
            {
                value = playerCard.GetPowerValue(Power.POISON_ID);
            }

            //opposingPlayerData.BattleField.FirstOrDefault(c => c.Id == ennemyCard.Id).AddStatusValue(Status.POISONED_ID, value);
            ennemyCard.AddStatusValue(Status.POISONED_ID, value);

            var pcs = ennemyCard.PlayableCardsStatus.First(c => c.StatusId == Status.POISONED_ID);
            if (pcs.Status == null)
            {
                pcs.Status = GameStatuses.Poisoned;
            }

            Duration = value;
            PlayerId = opposingPlayerData.PlayerId;
            OpposingPlayerData = opposingPlayerData;
        }
    }
}
