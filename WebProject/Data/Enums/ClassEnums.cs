using System.ComponentModel.DataAnnotations;

namespace WebProject.Data.Enums
{
    public enum ClassEnums
    {
        [Display(Name = "Basic", Description = "Bare bones weakling.")]
        Basic = 0,
        [Display(Name = "Warrior", Description = "Sturdy fighter.")]
        Warrior = 1,
        [Display(Name = "Rogue", Description = "Shady fighter.")]
        Rogue = 2,
    }
}
