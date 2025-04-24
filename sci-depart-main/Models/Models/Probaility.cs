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

        public double Value { get; set; }

        public Card.rareté Rarity { get; set; }

        public int BaseQty { get; set; }
    }
}
