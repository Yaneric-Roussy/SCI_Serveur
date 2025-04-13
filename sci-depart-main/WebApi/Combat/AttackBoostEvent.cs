using Super_Cartes_Infinies.Combat;

namespace Super_Cartes_Infinies.Combat
{
    public class AttackBoostEvent : MatchEvent
    {
        public override string EventType { get { return "AttackBoost"; } }

        public AttackBoostEvent()
        {

        }
    }
}
