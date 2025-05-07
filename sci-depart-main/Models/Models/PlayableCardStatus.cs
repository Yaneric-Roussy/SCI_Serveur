using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PlayableCardStatus
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int ValueId { get; set; }
        public virtual Status Status { get; set; }
    }
}
