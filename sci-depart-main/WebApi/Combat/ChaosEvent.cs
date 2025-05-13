using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class ChaosEvent : MatchEvent
    {
        public override string EventType { get { return "ChaosEvent"; } }
           public ChaosEvent(MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {
            this.Events = new List<MatchEvent>();
            AlterCards(currentPlayerData);
            AlterCards(opposingPlayerData);
        }

        public void AlterCards(MatchPlayerData playerData)
        {
            foreach (PlayableCard playableCard in playerData.BattleField)
            {
                //On inverse les deux valeurs
                int tempValue = playableCard.Health;
                playableCard.Health = playableCard.Attack;
                playableCard.Attack = tempValue;

                //On tue la carte si health est 0
                if (playableCard.Health == 0)
                {
                    Events.Add(new CardDeathEvent(playerData, playableCard));
                }
            }
        }
    }
}
