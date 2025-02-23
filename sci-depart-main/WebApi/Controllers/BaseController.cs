using System;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Super_Cartes_Infinies.Services;
using Super_Cartes_Infinies.Models;
using Models.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Super_Cartes_Infinies.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public PlayersService playersService;

        public BaseController(PlayersService playersService)
        {
            this.playersService = playersService;
        }

        private Player? player = null;

        public Player CurrentPlayer
        {
            get
            {
                if(player == null)
                {
                    player = playersService.GetPlayerFromUserId(UserId);
                }
                return player;
            }
        }

        public string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier)!; ;
            }
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

           

    


