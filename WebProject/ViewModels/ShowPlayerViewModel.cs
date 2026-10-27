using System.ComponentModel.DataAnnotations;
using WebProject.Data.Enums;

namespace WebProject.ViewModels
{
    public class ShowPlayerViewModel
    {

        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Class")]
        public ClassEnums CharacterClass { get; set; }

        [Display(Name = "Health")]
        public int PlayerHealth { get; set; }

        [Display(Name = "Strength")]
        public int PlayerStrength { get; set; }
        
        [Display(Name = "Level")]
        public int PlayerLevel { get; set; }

        [Display(Name = "Experience")]
        public int PlayerExperience { get; set; }

        [Display(Name = "Gold")]
        public int PlayerGold { get; set; }
    }
}
