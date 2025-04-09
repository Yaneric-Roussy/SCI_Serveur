using Super_Cartes_Infinies.Combat;

namespace WebApi.Combat
{
    public class AttackBoostEvent : MatchEvent
    {
        public override string EventType { get { return "AttackBoost"; } }

        public AttackBoostEvent()
        {

        }
    }
}
