using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Super_Cartes_Infinies.Controllers;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;
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
        public async Task<ActionResult> Adddeck(string name,string userid)
        {
            _deckService.AjoutDeck(name,userid);
            return Ok();
            
        }
        [HttpGet("{name}")]
        public async Task<ActionResult> GetDeck()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(_deckService.getDeck(userId));
        }

        public DeckController(ApplicationDbContext dbContext, DecksService decksService)
        {
            _dbContext = dbContext;
            _deckService = decksService;
        }

    }
}
