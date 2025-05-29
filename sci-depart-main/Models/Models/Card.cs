using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
	public class Card : IModel
	{
		public Card() { }
        public enum rareté { Commune, Rare, Épique, Légendaire };

        public int Id { get; set; }
		public string Name { get; set; } = "";
		public int Attack { get; set; }
		public int Health { get; set; }
		public int Cost { get; set; }
		public string ImageUrl { get; set; } = "";
		public rareté Rareté { get; set; } = 0;

		[ValidateNever]
		public virtual List<CardPower> CardPowers { get; set; }

		public bool IsSpell { get; set; } = false;

        [ValidateNever]
        public int? SpellId { get; set; }
        [ValidateNever]
		public virtual Spell? Spell { get; set; }
	}
}

