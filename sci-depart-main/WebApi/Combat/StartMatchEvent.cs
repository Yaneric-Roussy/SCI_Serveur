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
            
            //Shuffle current player
            
            var rng = new Random();
            int lastElementIndex = currentPlayerData.CardsPile.Count() - 1;

            void Shuffle(MatchPlayerData player)
            {
                for (int i = 0; i <= 25; i++)
                {
                    int pos1 = rng.Next(player.CardsPile.Count);
                    int pos2 = rng.Next(player.CardsPile.Count);
                    (player.CardsPile[pos1], player.CardsPile[pos2]) = (player.CardsPile[pos2], player.CardsPile[pos1]);
                }
            }

            Shuffle(currentPlayerData);
            Shuffle(opposingPlayerData);

            //for (int i = 0; i <= 25; i++)
            //{
            //    int pos1 = rng.Next(lastElementIndex);
            //    var pos2 = rng.Next(lastElementIndex);
            //    var temporaire = currentPlayerData.CardsPile[pos1];
            //    currentPlayerData.CardsPile[pos1] = currentPlayerData.CardsPile[pos2];
            //    currentPlayerData.CardsPile[pos2] = temporaire;
            //}
            ////Shuffle opposing player
            //int opplastElementIndex = opposingPlayerData.CardsPile.Count() - 1;
            //for (int i = 0; i <= 25; i++)
            //{
            //    int pos1 = rng.Next(opplastElementIndex);
            //    var pos2 = rng.Next(opplastElementIndex);
            //    var temporaire = opposingPlayerData.CardsPile[pos1];
            //    opposingPlayerData.CardsPile[pos1] = opposingPlayerData.CardsPile[pos2];
            //    opposingPlayerData.CardsPile[pos2] = temporaire;
            //}

            for (int i = 0; i < nbCardsToDraw; i++)
            {
                Events.Add(new DrawCardEvent(currentPlayerData));
                Events.Add(new DrawCardEvent(opposingPlayerData));
            }
            Events.Add(new PlayerStartTurnEvent(currentPlayerData, nbManaPerTurn));
        }
    }
}
