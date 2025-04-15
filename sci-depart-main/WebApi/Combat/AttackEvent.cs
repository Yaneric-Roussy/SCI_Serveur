using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class AttackEvent : MatchEvent
    {
        public override string EventType { get { return "Attack"; } }

        public int PlayerID { get; set; }
        public int PlayableCardId { get; set; }

        public AttackEvent(Match match,PlayableCard? ennemyCard,PlayableCard myCard, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData)
        {

            this.Events = new List<MatchEvent>();
            //Si jamais aucune carte n'est devant la carte, on attaque le joueur sinon on attaque la carte.
            PlayerID = currentPlayerData.PlayerId;
            PlayableCardId = myCard.Id;

            if (ennemyCard != null)
            {
                this.Events.Add(new CardDamageEvent(currentPlayerData, ennemyCard, myCard));
                this.Events.Add(new CardDamageEvent(opposingPlayerData, myCard, ennemyCard));
            }
            else
            {
                this.Events.Add(new PlayerDamageEvent(match, opposingPlayerData, currentPlayerData, myCard.Attack));
            }

        }
    }
}
