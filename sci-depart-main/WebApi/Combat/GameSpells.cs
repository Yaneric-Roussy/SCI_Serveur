using Models.Models;

namespace WebApi.Combat
{
    public class GameSpells
    {
        public static readonly Spell Earthquake = new Spell
        {
            Id = Spell.EARTHQUAKE_ID,
            Name = "Earthquake",
            Description = "Fait X dégâts à TOUTES les cartes en jeu.",
            Value = 2,
            Icone = "🌎"
        };
        public static readonly Spell Random_Pain = new Spell
        {
            Id = Spell.RANDOM_PAIN_ID,
            Name = "Random Pain",
            Description = "Fait 1 à 6 de dégâts à une carte adverse (au hazard).",
            Value = 0,
            Icone = "🤕"
        };
    }
}
