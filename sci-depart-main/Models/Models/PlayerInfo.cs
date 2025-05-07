using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PlayerInfo
    {
        public PlayerInfo() { }

        public int Id { get; set; }
        public int Elo { get; set; }
        public int Attente { get; set; }
        public string UserId { get; set; }

    }
}
