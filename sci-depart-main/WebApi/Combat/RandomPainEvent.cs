using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System.Runtime;

namespace WebApi.Combat
{
    public class RandomPainEvent : MatchEvent
    {
        public override string EventType { get { return "RandomPainEvent"; } }
        public RandomPainEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, PlayableCard playerCard)
        {
            this.Events = new List<MatchEvent>();
            Random random = new Random();
            
            //Randomly generated (1-6)
            int damage = random.Next(1, 7);

            //Get a random card from deck
            if (opposingPlayerData.BattleField != null || opposingPlayerData.BattleField.Count > 0)
            {
                int randomPickedCard = random.Next(0, opposingPlayerData.BattleField.Count);
                Events.Add(new CardDamageEvent(opposingPlayerData, damage, opposingPlayerData.BattleField[randomPickedCard]));
            }
        }
    }
}
