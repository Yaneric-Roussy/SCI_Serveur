using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDeathEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerDeath"; } }
       // public int WinningPlayerId { get; set; }
        public int LosingPlayerId { get; set; }
        public PlayerDeathEvent(Match match,MatchPlayerData deadPlayer, MatchPlayerData Player)
        {
            this.Events = new List<MatchEvent>();
            //WinningPlayerId = Player.PlayerId;
            LosingPlayerId = deadPlayer.PlayerId;
            this.Events.Add(new EndMatchEvent(match, Player, deadPlayer));
        }
    }
}
