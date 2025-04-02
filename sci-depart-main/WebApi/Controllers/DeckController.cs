using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class DeckController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
