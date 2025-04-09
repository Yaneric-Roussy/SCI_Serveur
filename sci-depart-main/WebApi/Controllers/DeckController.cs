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

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DeckController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private CardsService _cardsService;
        private DecksService _deckService;
        [HttpPost]
        public async Task<ActionResult> CreateDeck(Temp objet)
        {
            await _deckService.AjoutDeck(objet.Name, objet.PlayerId);
            return Ok();

        }
        [HttpGet("{playerId}")]
        public async Task<ActionResult> GetDeck(int playerId)
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(await _deckService.getDeck(playerId));
        }

        public DeckController(ApplicationDbContext dbContext, DecksService decksService)
        {
            _dbContext = dbContext;
            _deckService = decksService;
        }

    }
}
