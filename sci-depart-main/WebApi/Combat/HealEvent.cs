using Super_Cartes_Infinies.Combat;

namespace WebApi.Combat
{
    public class HealEvent : MatchEvent
    {
        public override string EventType { get { return "Heal"; } }

        public HealEvent()
        {

        }
    }
}
