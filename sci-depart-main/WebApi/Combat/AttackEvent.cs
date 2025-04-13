using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class AttackEvent : MatchEvent
    {
        public override string EventType { get { return "Attack"; } }

        public int Dps { get; set; }
        public int? CardPos { get; set; }

        public AttackEvent(PlayableCard? cardAttack,int dps,  int cardPos)
        {
            //Si jamais aucune carte n'est devant la carte, on attaque le joueur sinon on attaque la carte.
            Dps = dps;
            if (cardAttack == null)
            {
                CardPos = null;
            }
            else
            {
                CardPos = cardPos;
            }

        }
    }
}
