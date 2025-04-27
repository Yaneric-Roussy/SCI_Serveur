using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDeathEvent : MatchEvent
    {
        public override string EventType { get { return "CardDeath"; } }

        public int PlayerId {  get; set; }
        public int DeadCardId { get; set; }
        public CardDeathEvent(MatchPlayerData PlayerData, PlayableCard card)
        {
            DeadCardId = card.Id;
            PlayerId = PlayerData.PlayerId;

            //Update l'index :|
            for(int i = card.Index + 1; i < PlayerData.BattleField.Count() - 1; i++) 
            {
                PlayerData.BattleField[i].Index = i - 1;
            }

            PlayerData.BattleField.Remove(card);
            PlayerData.Graveyard.Add(card);
        }
    }
}