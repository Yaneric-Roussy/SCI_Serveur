using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Super_Cartes_Infinies.Controllers;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class Temp
    {
        public string Name { get; set; }
        public int PlayerId { get; set; }
    }
    public class AjoutCarte
    {
        public int PlayerId { get; set; }
        public int CarteID{ get; set; }
        public int DeckID { get; set; }
    }

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DeckController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private CardsService _cardsService;
        private DecksService _deckService;
        [HttpPost]
        public async Task<ActionResult<Deck>> CreateDeck(Temp objet)
        {
           
            return Ok(await _deckService.AjoutDeck(objet.Name, objet.PlayerId));

        }
        [HttpGet("{playerId}")]
        public async Task<ActionResult> GetDeck(int playerId)
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(await _deckService.getDeck(playerId));
        }
        [HttpPost]
        public async Task<ActionResult>AjoutDcarte(AjoutCarte ajout)
        {
            return Ok(_deckService.AddCarte(ajout.PlayerId,ajout.CarteID,ajout.DeckID ));
        }

        public DeckController(ApplicationDbContext dbContext, DecksService decksService)
        {
            _dbContext = dbContext;
            _deckService = decksService;
        }
        [HttpDelete]
        public async Task<ActionResult<Deck>> DeleteCarte(int deckID , int OwnedCardId)
        {
            return Ok (_deckService.DeleteCarte(deckID, OwnedCardId));
        }

    }
}
