using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System.Runtime;

namespace WebApi.Combat
{
    public class EarthquakeEvent : MatchEvent
    {
        public override string EventType { get { return "EarthquakeEvent"; } }
        public EarthquakeEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, PlayableCard playerCard)
        {
            //Should have one as it triggered the event
            int damage = playerCard.Card.Spell!.Value;
            this.Events = new List<MatchEvent>();

            //Earthquake attacks ALL CARDS
            DamageCards(currentPlayerData, damage);
            if(opposingPlayerData.BattleField != null || opposingPlayerData.BattleField.Count > 0)
                DamageCards(opposingPlayerData, damage);

        }

        public void DamageCards(MatchPlayerData playerData, int damage)
        {
            var cardsToDamage = playerData.BattleField.ToList();

            foreach (PlayableCard playableCard in cardsToDamage)
            {
                Events.Add(new CardDamageEvent(playerData, damage, playableCard));
            }
        }

    }
}
