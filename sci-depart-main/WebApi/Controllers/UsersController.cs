using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Models.Dtos;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        public PlayersService playersService;
        readonly UserManager<Player> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public UsersController(UserManager<Player> userManager, PlayersService playersService, SignInManager<IdentityUser> signInManager)
            {
                _userManager = userManager;
            this.playersService = playersService;
            _signInManager = signInManager;

        }
     
        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Les deux mots de passe spécifiés sont différents." });
            }

            IdentityUser user = new IdentityUser
            {
                UserName = register.Username,
                Email = register.Email
            };

            IdentityResult identityResult = await playersService.CreateAssync(user);

            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "La création de l'utilisateur a échoué." });
            }

            return Ok(new { Message = "Inscription réussie ! 🥳" });
        }


    }

}

