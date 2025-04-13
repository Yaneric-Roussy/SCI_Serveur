using System.Text.Json.Serialization;

namespace Super_Cartes_Infinies.Combat
{
    [JsonDerivedType(typeof(DrawCardEvent))]
    [JsonDerivedType(typeof(EndMatchEvent))]
    [JsonDerivedType(typeof(GainManaEvent))]
    [JsonDerivedType(typeof(PlayerEndTurnEvent))]
    [JsonDerivedType(typeof(PlayerStartTurnEvent))]
    [JsonDerivedType(typeof(StartMatchEvent))]
    [JsonDerivedType(typeof(SurrenderEvent))]
    [JsonDerivedType(typeof(AttackBoostEvent))]
    [JsonDerivedType(typeof(AttackEvent))]
    [JsonDerivedType(typeof(CardActivationEvent))]
    [JsonDerivedType(typeof(FirstStrikeEvent))]
    [JsonDerivedType(typeof(HealEvent))]
    [JsonDerivedType(typeof(ThornsEvent))]
    [JsonDerivedType(typeof(PlayCardEvent))]
    public abstract class MatchEvent
    {
        public abstract string EventType { get; }

        public MatchEvent()
        {
        }

        public List<MatchEvent>? Events { get; set; }
    }
}
