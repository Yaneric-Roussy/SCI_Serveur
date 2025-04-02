using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Super_Cartes_Infinies.Controllers;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Services;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DeckController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private CardsService _cardsService;
        private DecksService _deckService;
        [HttpGet]
        public async Task<ActionResult> Adddeck(string name)
        {
            _deckService.AjoutDeck(name);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetDeck(string name)
        {
            _deckService.getDeck( name);
            return Ok();
        }

        public DeckController(ApplicationDbContext dbContext, DecksService decksService)
        {
            _dbContext = dbContext;
            _deckService = decksService;
        }

    }
}
