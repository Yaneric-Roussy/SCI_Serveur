using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDamageEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerDamage"; } }
        public int PlayerId { get; set; }
        public int Damage { get; set; }
        public PlayerDamageEvent(Match match, MatchPlayerData AttackedPlayer, MatchPlayerData AttackingPlayer, int dps)
        {
            this.Events = new List<MatchEvent>();

            AttackedPlayer.Health -= dps;
            Damage = dps;
            PlayerId = AttackedPlayer.Id;
            if (AttackedPlayer.Health <= 0)
            {
                this.Events.Add(new EndMatchEvent(match, AttackingPlayer, AttackedPlayer));
            }
        }
    }
}
