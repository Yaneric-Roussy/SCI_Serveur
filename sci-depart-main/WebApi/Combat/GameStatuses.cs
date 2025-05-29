using Models.Models;

namespace WebApi.Combat
{
    public static class GameStatuses
    {
        public static readonly Status Poisoned = new Status
        {
            Id = Status.POISONED_ID,
            Name = "Poisoned",
            Description = "La carte est poisoned, elle prend du dégât de poison.",
            Icone = "🧪"
        };

        public static readonly Status Stunned = new Status
        {
            Id = Status.STUNNED_ID,
            Name = "Stunned",
            Description = "La carte est étourdie, elle ne peut pas attaquer.",
            Icone = "💫"
        };

        public static readonly Status Protected = new Status
        {
            Id = Status.PROTECTED_ID,
            Name = "Protected",
            Description = "Donne l'invulnérabilité à la carte durant X tours. La carte ne peut pas prendre de dégâts, même des sorts.",
            Icone = "🛡"
        };
    }
}
