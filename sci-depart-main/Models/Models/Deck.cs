using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
  public class Deck
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        [ValidateNever]
        public virtual List<OwnedCard> CarteJoueurs { get; set; }
        //public int NbMaxCarte { get; }
        public string UserId { get; set; }
        public bool Courant { get; set; }

        public Deck() { }

        public Deck(string pUserId)
        {
            Name = "Depart";
            UserId = pUserId;
            Courant = true;
            CarteJoueurs = new List<OwnedCard>();
        }

    }
}
