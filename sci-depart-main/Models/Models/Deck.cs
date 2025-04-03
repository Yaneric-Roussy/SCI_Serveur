using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
  public class Deck
    {
        public int Deckid { get; set; }
        public String Name{ get; set; }
        [ValidateNever]
        public virtual List<OwnedCard> CarteJoueurs { get; set; }
        public int nbMaxCarte { get; set; }
        [ValidateNever]
        public virtual IdentityUser user { get; set; }
        public bool Courant { get; set; }


        public Deck()
        {
                nbMaxCarte=CarteJoueurs.Count();
        }

    }
}
