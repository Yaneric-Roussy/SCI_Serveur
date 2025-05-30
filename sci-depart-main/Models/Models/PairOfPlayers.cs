using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Interfaces;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PairOfPlayers
    {
        public PairOfPlayers(PlayerInfo player1, PlayerInfo player2) 
        {
            PlayerInfo1 = player1;
            PlayerInfo2 = player2;
        }

        public PlayerInfo PlayerInfo1 { get; set; }
        public PlayerInfo PlayerInfo2 { get; set; }
    }
}
