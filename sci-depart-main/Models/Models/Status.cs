using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Status
    {
        public const int POISONED_ID = 1;
        public const int STUNNED_ID = 2;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icone { get; set; }
    }
}
