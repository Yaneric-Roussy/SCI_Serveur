using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class HealEvent : MatchEvent
    {
        public override string EventType { get { return "Heal"; } }

        public HealEvent(MatchPlayerData currentPlayerData, PlayableCard card)
        {
            this.Events = new List<MatchEvent>();
            
            for (int i = 0; i < currentPlayerData.BattleField.Count(); i++)
            {
                this.Events.Add(new CardHealEvent(currentPlayerData.BattleField[i],card.GetPowerValue(Power.HEAL_ID), currentPlayerData));

            }
        }
    }
}
