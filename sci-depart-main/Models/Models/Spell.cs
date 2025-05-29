using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Spell
    {
        public const int EARTHQUAKE_ID = 1;
        public const int RANDOM_PAIN_ID = 2;
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Value { get; set; }
        public string Icone { get; set; } = null!;
    }
}
