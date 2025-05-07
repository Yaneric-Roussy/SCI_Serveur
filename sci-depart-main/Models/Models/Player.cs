using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
	public class Player : IModel
    {
		public Player()
		{
		}

		public int Id { get; set; }
		public string Name { get; set; } = "";
		public required string UserId { get; set; }
		public int Money { get; set; } = 20;
		[JsonIgnore]
		public virtual IdentityUser User { get; set; }
		public virtual List<OwnedCard> OwnedCards { get; set; } = null!;
		public virtual List<Deck> listeDeck { get; set; } = null;

		public int? PlayerInfoId { get; set; }
		public virtual PlayerInfo? playerInfo { get; set; } = null!;

    }
}

