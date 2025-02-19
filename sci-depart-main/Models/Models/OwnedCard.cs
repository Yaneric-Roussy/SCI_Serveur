using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Models
{
    internal class OwnedCard
    {
        public int Id { get; set; }
        public Card CardId  { get; set; }
        public Player PlayerId { get; set; }
    }
}
