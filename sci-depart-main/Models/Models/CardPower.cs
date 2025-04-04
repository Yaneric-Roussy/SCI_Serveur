using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CardPower
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
        public int PowerId { get; set; }
        public virtual Power Power { get; set; }
        //Pour donner une puissance a un pouvoir. Ex : Heal 1 permet de heal de 1 point.
        public int Value { get; set; }
    }
}
