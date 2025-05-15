using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

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
            int value = playerCard.GetPowerValue(Power.POISON_ID);


            opposingPlayerData.BattleField.FirstOrDefault(c => c.Id == ennemyCard.Id).AddStatusValue(Status.POISONED_ID, value);


            Duration = value;
            PlayerId = opposingPlayerData.PlayerId;
            OpposingPlayerData = opposingPlayerData;
        }
    }
}
