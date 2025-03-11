using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System;

namespace Super_Cartes_Infinies.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardController : BaseController
    {
        private ApplicationDbContext _dbContext;
        private CardsService _cardsService;

        public CardController(ApplicationDbContext dbContext, CardsService cardsService, PlayersService playersService):base(playersService)
        {
            _dbContext = dbContext;
            _cardsService = cardsService;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAllCards(int? champ, int? ordre)
        {
            if(ordre == 1)
            {
                switch (champ)
                {
                    case 0:
                        return Ok(_cardsService.GetAllCards().OrderByDescending(i => i.Attack));
                    case 1:
                        return Ok(_cardsService.GetAllCards().OrderByDescending(i => i.Health));
                    case 2:
                        return Ok(_cardsService.GetAllCards().OrderByDescending(i => i.Cost));
                }
                    
            }
            if (ordre == null && ordre == null)
            {
                return Ok(_cardsService.GetPlayersCards("TheIdOfTheUser"));
            }
            switch (champ)
            {
                case 0:
                    return Ok(_cardsService.GetAllCards().OrderBy(i => i.Attack));
                case 1:
                    return Ok(_cardsService.GetAllCards().OrderBy(i => i.Health));
                case 2:
                    return Ok(_cardsService.GetAllCards().OrderBy(i => i.Cost));
            }
            return BadRequest("Champ de tri invalide");
        }

        // TODO: La version réelle devra utiliser [Authorize] pour protéger les données est s'assurer d'avoir accès au User
        // Et l'utiliser pour obtenir l'Id de l'utilisateur
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetPlayersCards(int? champ, int? ordre)
        {
            if (ordre == null && ordre == null)
            {
                return Ok(_cardsService.GetPlayersCards("TheIdOfTheUser"));
            }
            if (ordre == 1)
            {
                switch (champ)
                {
                    case 0:
                        return Ok(_cardsService.GetPlayersCards("TheIdOfTheUser").OrderByDescending(i => i.Attack));
                    case 1:
                        return Ok(_cardsService.GetPlayersCards("TheIdOfTheUser").OrderByDescending(i => i.Health));
                    case 2:
                        return Ok(_cardsService.GetPlayersCards("TheIdOfTheUser").OrderByDescending(i => i.Cost));
                }

            }
            switch (champ)
            {
                case 0:
                    return Ok(_cardsService.GetPlayersCards("TheIdOfTheUser").OrderBy(i => i.Attack));
                case 1:
                    return Ok(_cardsService.GetPlayersCards("TheIdOfTheUser").OrderBy(i => i.Health));
                case 2:
                    return Ok(_cardsService.GetPlayersCards("TheIdOfTheUser").OrderBy(i => i.Cost));
            }
            return BadRequest("Champ de tri invalide");
        }
    }
}
