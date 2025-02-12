using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class StartMatchEvent : MatchEvent
    {
        public override string EventType { get { return "StartMatch"; } }
        public StartMatchEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int nbCardsToDraw, int nbManaPerTurn)
        {
            Events = new List<MatchEvent> { };

            // TODO: Faire piger le nombre de cartes de la configuration (nbCardsToDraw) au DEUX joueurs

            Events.Add(new PlayerStartTurnEvent(currentPlayerData, nbManaPerTurn));
        }
    }
}
