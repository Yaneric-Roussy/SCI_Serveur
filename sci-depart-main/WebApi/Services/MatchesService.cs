using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;

namespace Super_Cartes_Infinies.Services
{
	public class MatchesService
    {
        private WaitingUserService _waitingUserService;
        private PlayersService _playersService;
        private CardsService _cardsService;
        private MatchConfigurationService _matchConfigurationService;
        private ApplicationDbContext _dbContext;

        public MatchesService(ApplicationDbContext context, WaitingUserService waitingUserService, PlayersService playersService, CardsService cardsService, MatchConfigurationService matchConfigurationService)        {
            _dbContext = context;
            _waitingUserService = waitingUserService;
            _playersService = playersService;
            _cardsService = cardsService;
            _matchConfigurationService = matchConfigurationService;
        }


        public async Task<JoiningMatchData?> JoinMatchSpectator(string userId, int specificMatchId)
        {
            Match? match = await _dbContext.Matches.FirstOrDefaultAsync(m => m.Id == specificMatchId);
            if (match != null)
            {
                return new JoiningMatchData
                {
                    Match = match,
                    PlayerA = match.PlayerDataA.Player,
                    PlayerB = match.PlayerDataB.Player,
                    IsStarted = true
                };
            }

            return null;
        }

        //// Cette fonction est assez flexible car elle peut simplement être appeler lorsqu'un user veut jouer un match
        //// Si le user a déjà un match en cours (Un match qui n'est pas terminé), on lui retourne l'information pour ce match
        //// Sinon on utilise le WaitingUserService pour essayer de trouver un autre user ou nous mettre en attente
        //public async Task<JoiningMatchData?> JoinMatch(string userId, string? connectionId, int? specificMatchId)
        //{
        //    // Vérifier si le match n'a pas déjà été démarré (de façon plus générale, retourner un match courrant si le joueur y participe)
        //    IEnumerable<Match> matches = _dbContext.Matches.Where(m => m.IsMatchCompleted == false && (m.UserAId == userId || m.UserBId == userId));


        //    if(matches.Count() > 1)
        //    {
        //        throw new Exception("A player should never be playing 2 matches at the same time!");
        //    }

        //    Match? match = null;
        //    Player? playerA = null;
        //    Player? playerB = null;
        //    string otherPlayerConnectionId = null;

        //    // Le joueur est dans un match en cours
        //    if (matches.Count() == 1)
        //    {
        //        match = matches.First();
        //        if(specificMatchId != null && specificMatchId != match.Id )
        //        {
        //            match = null;
        //        }
        //        else
        //        {
        //            playerA = _playersService.GetPlayerFromUserId(match.UserAId);
        //            playerB = _playersService.GetPlayerFromUserId(match.UserBId);
        //        }
        //    }
        //    // Si on veut rejoindre un match en particulier, on ne se met pas en file
        //    else if(specificMatchId == null)
        //    {
        //        UsersReadyForAMatch? pairOfUsers = await _waitingUserService.LookForWaitingUser(userId, connectionId);

        //        if (pairOfUsers != null)
        //        {
        //            playerA = _playersService.GetPlayerFromUserId(pairOfUsers.UserAId);
        //            playerB = _playersService.GetPlayerFromUserId(pairOfUsers.UserBId);

        //            // Création d'un nouveau match
        //            IEnumerable<Card> cardsPlayerA = await _cardsService.GetUserDeckCards(playerA.Id);
        //            IEnumerable<Card> cardsPlayerB = await _cardsService.GetUserDeckCards(playerB.Id);
        //            match = new Match(playerA, playerB, cardsPlayerA, cardsPlayerB);
        //            otherPlayerConnectionId = pairOfUsers.UserAConnectionId;

        //            _dbContext.Update(match);
        //            _dbContext.SaveChanges();
        //        }
        //    }

        //    if(match != null) {
        //        return new JoiningMatchData
        //        {
        //            Match = match,
        //            PlayerA = playerA!,
        //            PlayerB = playerB!,
        //            OtherPlayerConnectionId = otherPlayerConnectionId,
        //            IsStarted = otherPlayerConnectionId == null
        //        };
        //    }

        //    return null;
        //}


        // Cette fonction est assez flexible car elle peut simplement être appeler lorsqu'un user veut jouer un match
        // Si le user a déjà un match en cours (Un match qui n'est pas terminé), on lui retourne l'information pour ce match
        // Sinon on utilise le WaitingUserService pour essayer de trouver un autre user ou nous mettre en attente
        public async Task<JoiningMatchData?> JoinMatch(string userId, string? connectionId, int? specificMatchId, bool first)
        {
            // Vérifier si le match n'a pas déjà été démarré (de façon plus générale, retourner un match courrant si le joueur y participe)
            IEnumerable<Match> matches = _dbContext.Matches.Where(m => m.IsMatchCompleted == false && (m.UserAId == userId || m.UserBId == userId));


            if (matches.Count() > 1)
            {
                throw new Exception("A player should never be playing 2 matches at the same time!");
            }

            Match? match = null;
            Player? playerA = null;
            Player? playerB = null;
            string otherPlayerConnectionId = null;

            // Le joueur est dans un match en cours
            if (matches.Count() == 1)
            {
                match = matches.First();
                if (specificMatchId != null && specificMatchId != match.Id)
                {
                    match = null;
                }
                else
                {
                    if (first)
                    {
                        playerA = _playersService.GetPlayerFromUserId(match.UserAId);
                        playerB = _playersService.GetPlayerFromUserId(match.UserBId);

                        return new JoiningMatchData
                        {
                            Match = match,
                            PlayerA = playerA!,
                            PlayerB = playerB!,
                            OtherPlayerConnectionId = otherPlayerConnectionId!,
                            IsStarted = false
                        };
                    }
                    else
                    {
                        playerA = _playersService.GetPlayerFromUserId(match.UserAId);
                        playerB = _playersService.GetPlayerFromUserId(match.UserBId);
                        otherPlayerConnectionId = connectionId!;
                        return new JoiningMatchData
                        {
                            Match = match,
                            PlayerA = playerA!,
                            PlayerB = playerB!,
                            OtherPlayerConnectionId = otherPlayerConnectionId!,
                            IsStarted = true
                        };
                    }
                    

                }
            }
            // Si on veut rejoindre un match en particulier, on ne se met pas en file
            else if (specificMatchId == null && matches.Count() == 0)
            {
                Player? player = await _dbContext.Players.Where(p => p.UserId == userId).SingleOrDefaultAsync();
                if (player != null)
                {
                    PlayerInfo? playerInfo = player.playerInfo;
                    if (playerInfo != null)
                    {
                        playerInfo.Attente = 0;                        
                    }
                    else
                    {
                        player.playerInfo = new PlayerInfo()
                        {
                            Elo = 1000,
                            UserId = player.UserId,
                            Player = player,
                            Attente = 0
                        };
                    }
                }
                await _dbContext.SaveChangesAsync();
                //UsersReadyForAMatch? pairOfUsers = await _waitingUserService.LookForWaitingUser(userId, connectionId);


                //if (pairOfUsers != null)
                //{
                //    playerA = _playersService.GetPlayerFromUserId(pairOfUsers.UserAId);
                //    playerB = _playersService.GetPlayerFromUserId(pairOfUsers.UserBId);

                //    // Création d'un nouveau match
                //    IEnumerable<Card> cardsPlayerA = await _cardsService.GetUserDeckCards(playerA.Id);
                //    IEnumerable<Card> cardsPlayerB = await _cardsService.GetUserDeckCards(playerB.Id);
                //    match = new Match(playerA, playerB, cardsPlayerA, cardsPlayerB);
                //    otherPlayerConnectionId = pairOfUsers.UserAConnectionId;

                //    _dbContext.Update(match);
                //    _dbContext.SaveChanges();
                //}


                //if (match != null)
                //{
                //    return new JoiningMatchData
                //    {
                //        Match = match,
                //        PlayerA = playerA!,
                //        PlayerB = playerB!,
                //        OtherPlayerConnectionId = otherPlayerConnectionId,
                //        IsStarted = otherPlayerConnectionId == null
                //    };
                //}

            }
            return null;
        }

        public async Task<bool> PartMatch(PairOfPlayers pair)
        {
            // Création d'un nouveau match
            IEnumerable<Card> cardsPlayerA = await _cardsService.GetUserDeckCards(pair.PlayerInfo1.Player.Id);
            IEnumerable<Card> cardsPlayerB = await _cardsService.GetUserDeckCards(pair.PlayerInfo2.Player.Id);
            Match match = new Match(pair.PlayerInfo1.Player, pair.PlayerInfo2.Player, cardsPlayerA, cardsPlayerB);


            _dbContext.Update(match);
            _dbContext.SaveChanges();

            
            //if (match != null)
            //{
            //    return new JoiningMatchData
            //    {
            //        Match = match,
            //        PlayerA = playerA!,
            //        PlayerB = playerB!,
            //        OtherPlayerConnectionId = otherPlayerConnectionId,
            //        IsStarted = otherPlayerConnectionId == null
            //    };
            //}
            return true;
        }

        public async Task<bool> StopJoiningMatch(string userId)
        {
            bool stoppedWaiting = await _waitingUserService.StopWaitingUser(userId);

            return stoppedWaiting;
        }

        // L'action retourne le json de l'event de création de match (StartMatchEvent)
        public async Task<StartMatchEvent> StartMatch(string currentUserId, int matchId)
        {
            Match? match = await _dbContext.Matches.FirstOrDefaultAsync(m => m.Id == matchId);
            if (match == null)
            {
                return null;
            }
            MatchPlayerData currentPlayerData;
            MatchPlayerData opposingPlayerData;

            if (match.UserAId == currentUserId)
            {
                currentPlayerData = match.PlayerDataA;
                opposingPlayerData = match.PlayerDataB;
            }
            else
            {
                currentPlayerData = match.PlayerDataB;
                opposingPlayerData = match.PlayerDataA;
            }
            
          
           
            
     
            int nbCardsToDraw = _matchConfigurationService.GetNbCardsToDraw();
            int nbManaPerTurn = _matchConfigurationService.GetNbManaPerTurn();
            var startMatchEvent = new StartMatchEvent(match, currentPlayerData, opposingPlayerData, nbCardsToDraw, nbManaPerTurn);
            await _dbContext.SaveChangesAsync();

            return startMatchEvent;
        }

        public async Task<PlayerEndTurnEvent> EndTurn(string userId, int matchId)
        {
            Match? match = await _dbContext.Matches.FindAsync(matchId);

            if (match == null)
                throw new Exception("Impossible de trouver le match");

            if (match.IsMatchCompleted)
                throw new Exception("Le match est déjà terminé");

            if (match.UserAId != userId && match.UserBId != userId)
                throw new Exception("Le joueur n'est pas dans ce match");

            if ((match.UserAId == userId) != match.IsPlayerATurn)
                throw new Exception("Ce n'est pas le tour de ce joueur");

            MatchPlayerData currentPlayerData;
            MatchPlayerData opposingPlayerData;

            if (match.UserAId == userId)
            {
                currentPlayerData = match.PlayerDataA;
                opposingPlayerData = match.PlayerDataB;
            }
            else
            {
                currentPlayerData = match.PlayerDataB;
                opposingPlayerData = match.PlayerDataA;
            }

            int nbManaPerTurn = _matchConfigurationService.GetNbManaPerTurn();
            var playerEndTurnEvent = new PlayerEndTurnEvent(match, currentPlayerData, opposingPlayerData, nbManaPerTurn);

            await _dbContext.SaveChangesAsync();

            return playerEndTurnEvent;
        }

        public async Task<SurrenderEvent> Surrender(string userId, int matchId)
        {
            Match? match = await _dbContext.Matches.FindAsync(matchId);

            if (match == null)
                throw new Exception("Impossible de trouver le match");

            if (match.IsMatchCompleted)
                throw new Exception("Le match est déjà terminé");

            if (match.UserAId != userId && match.UserBId != userId)
                throw new Exception("Le joueur n'est pas dans ce match");

            MatchPlayerData currentPlayerData;
            MatchPlayerData opposingPlayerData;

            if (match.UserAId == userId)
            {
                currentPlayerData = match.PlayerDataA;
                opposingPlayerData = match.PlayerDataB;
            }
            else
            {
                currentPlayerData = match.PlayerDataB;
                opposingPlayerData = match.PlayerDataA;
            }

            var surrenderEvent = new SurrenderEvent(match, currentPlayerData, opposingPlayerData);

            await _dbContext.SaveChangesAsync();

            return surrenderEvent;
        }

        //PlayCard service

        public async Task<PlayCardEvent> PlayCard(string userId, int matchId, int cardId)
        {
            Match? match = await _dbContext.Matches.FindAsync(matchId);

            if (match == null)
                throw new Exception("Impossible de trouver le match");

            if (match.IsMatchCompleted)
                throw new Exception("Le match est déjà terminé");

            if (match.UserAId != userId && match.UserBId != userId)
                throw new Exception("Le joueur n'est pas dans ce match");

            MatchPlayerData currentPlayerData;

            if (match.UserAId == userId)
            {
                currentPlayerData = match.PlayerDataA;
            }
            else
            {
                currentPlayerData = match.PlayerDataB;
            }
            PlayableCard? card = currentPlayerData.Hand.Find(e => e.Id == cardId);
            if(card == null)
            {
                throw new Exception("La carte n'a pas été trouvé dans le jeu du joueur");
            }
            if(currentPlayerData.Mana - card.Card.Cost < 0)
            {
                throw new Exception("Pas assez de mana");
            }
            var playCardEvent = new PlayCardEvent(currentPlayerData, card);

            await _dbContext.SaveChangesAsync();

            return playCardEvent;
        }


       public void Statdeckfin()
        {

        }
    }
}

