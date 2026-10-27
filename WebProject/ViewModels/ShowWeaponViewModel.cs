using System.ComponentModel.DataAnnotations;
using WebProject.Data.Enums;

namespace WebProject.ViewModels
{
    public class ShowWeaponViewModel
    {

        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Damage")]
        public int WeaponDamage { get; set; }

        [Display(Name = "Strength")]
        public int WeaponStrength { get; set; }
    }
}
