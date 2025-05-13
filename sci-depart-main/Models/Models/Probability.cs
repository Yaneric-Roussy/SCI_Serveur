using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Probability
    {
        public int Id { get; set; }
        public double Value { get; set; }

        public Card.rareté Rarity { get; set; }

        public int BaseQty { get; set; }

        public int PackId { get; set; }

        public virtual Pack Pack { get; set; }
    }
}
