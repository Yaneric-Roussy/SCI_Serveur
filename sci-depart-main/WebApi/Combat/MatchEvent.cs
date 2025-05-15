using System.Text.Json.Serialization;

namespace Super_Cartes_Infinies.Combat
{
    [JsonDerivedType(typeof(DrawCardEvent))]
    [JsonDerivedType(typeof(EndMatchEvent))]
    [JsonDerivedType(typeof(GainManaEvent))]
    [JsonDerivedType(typeof(PlayerEndTurnEvent))]
    [JsonDerivedType(typeof(PlayerStartTurnEvent))]
    [JsonDerivedType(typeof(PlayerDamageEvent))]
    [JsonDerivedType(typeof(PlayerDeathEvent))]
    [JsonDerivedType(typeof(StartMatchEvent))]
    [JsonDerivedType(typeof(SurrenderEvent))]
    [JsonDerivedType(typeof(AttackEvent))]
    [JsonDerivedType(typeof(CardActivationEvent))]
    [JsonDerivedType(typeof(CardDamageEvent))]
    [JsonDerivedType(typeof(CardDeathEvent))]
    [JsonDerivedType(typeof(FirstStrikeEvent))]
    [JsonDerivedType(typeof(HealEvent))]
    [JsonDerivedType(typeof(ThornsEvent))]
    [JsonDerivedType(typeof(PlayCardEvent))]
    [JsonDerivedType(typeof(CardHealEvent))]
    [JsonDerivedType(typeof(DamageBoostEvent))]
    [JsonDerivedType(typeof(ChaosEvent))]
    [JsonDerivedType(typeof(PoisonEvent))]
    public abstract class MatchEvent
    {
        public abstract string EventType { get; }

        public MatchEvent()
        {
        }

        public List<MatchEvent>? Events { get; set; }
    }
}
