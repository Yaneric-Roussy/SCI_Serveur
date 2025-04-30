using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Pack : IModel
    {
        public Pack() { }

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int NbCard { get; set; }
        public int Cost { get; set; }
        public string ImageUrl { get; set; } = "";
        public raretéPack Rareté { get; set; } = 0;
        public type Type { get; set; } = 0;
        public enum raretéPack { Commune, Rare, Épique, Légendaire };
        public enum type { Basic,  Normal, Super };

    }
}
