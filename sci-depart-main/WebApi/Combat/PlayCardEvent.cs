using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerCard"; } }
        // TODO: Ajouter tout ce qui manque
        public PlayCardEvent(MatchPlayerData currentPlayerData, int playableCardId)
        {
        }
    }
}
