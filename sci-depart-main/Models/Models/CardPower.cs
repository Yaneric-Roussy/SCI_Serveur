using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CardPower
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        [JsonIgnore] //On ignore Card pour éviter références circulaires (card.CardPower, ...)
        public virtual Card Card { get; set; }
        public int PowerId { get; set; }
        public virtual Power Power { get; set; }
        //Pour donner une puissance a un pouvoir. Ex : Heal 1 permet de heal de 1 point.
        public int Value { get; set; }

        //Valeurs pour activation des pouvoirs
        [NotMapped]
        public int flipCount { get; set; }
        [NotMapped]
        public int shakeCount { get; set; }
        [NotMapped]
        public bool rotate { get; set; }
        [NotMapped]
        public bool pulsate { get; set; }
        [NotMapped]
        public bool showName { get; set; }
    }
}
