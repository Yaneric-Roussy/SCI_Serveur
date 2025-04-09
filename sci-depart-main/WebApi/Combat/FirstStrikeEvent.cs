using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class FirstStrikeEvent : MatchEvent
    {
        public override string EventType { get { return "FirstStrike"; } }

        public FirstStrikeEvent()
        {

        }
    }
}
