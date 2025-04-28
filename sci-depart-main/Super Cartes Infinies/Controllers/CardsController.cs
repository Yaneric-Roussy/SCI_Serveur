using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Controllers
{
    [Authorize(Roles = "admin")]
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Attack,Health,Cost,ImageUrl,Rareté")] Card card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            ViewData["PowersList"] = new SelectList(await GetAvailablePowers(card), "Id", "Display");
            return View(card);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCardPower(int? cardPowerId, int? cardId)
        {
            if (cardPowerId == null || cardId == null)
            {
                return NotFound();
            }

            var cardPower = await _context.CardPower.FindAsync(cardPowerId);
            var card = await _context.Cards.FindAsync(cardId);
            if (cardPower == null || card == null)
            {
                return NotFound();
            }
            else
            {
                _context.CardPower.Remove(cardPower);
                await _context.SaveChangesAsync();
                ViewData["PowersList"] = new SelectList(await GetAvailablePowers(card), "Id", "Display");
            }

            return RedirectToAction(nameof(Edit), "Cards", new { id = card.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCardPower(int? powerId, int? powerValue, int? cardId)
        {
            if(powerId == null || cardId == null)
            {
                return NotFound();
            }
            if (powerValue == null)
                powerValue = 0;

            var card = await _context.Cards.FindAsync(cardId);
            var power = await _context.Power.FindAsync(powerId);
            if(card == null || power == null)
            {
                return NotFound();
            }

            CardPower cardPower = new CardPower
            {
                PowerId = (int)powerId,
                CardId = (int)cardId,
                Card = card,
                Power = power,
                Value = (int)powerValue
            };

            _context.CardPower.Add(cardPower);
            await _context.SaveChangesAsync();

            ViewData["PowersList"] = new SelectList(await GetAvailablePowers(card), "Id", "Display");
            return RedirectToAction(nameof(Edit), "Cards", new { id = card.Id });

        }

        public async Task<List<object>> GetAvailablePowers(Card card)
        {
            var assignedPowerIds = card.CardPowers.Select(cp => cp.Power.Id).ToList();

            if(assignedPowerIds.Count != 0)
            {
                var availablePowers = await _context.Power
                    .Where(p => !assignedPowerIds.Contains(p.Id))
                    .Select(p => new
                    {
                        p.Id,
                        Display = p.IconeURL + " " + p.Name
                    })
                    .Cast<object>() //Cast en objet car pas de classe avec Id et Display
                    .ToListAsync();

                return availablePowers;
            }

            var allPowers = await _context.Power
                .Select(p => new
                {
                    p.Id,
                    Display = p.IconeURL + " " + p.Name
                })
                .Cast<object>()
                .ToListAsync();

            return allPowers;
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Attack,Health,Cost,ImageUrl,Rareté")] Card card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                _context.Cards.Remove(card);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }

     
        public async Task<IActionResult> CreateStarting(int id)
        {

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);

            if (card == null) return NotFound();

            return View(card);
        }

        [HttpPost, ActionName("CreateStartingCard")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStartingCardConfirmed(int id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            if (card == null) return NotFound();

            var startingCard = new StartingCard(card);
            _context.StartingCards.Add(startingCard);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "StartingCards");
        }
    }
}
