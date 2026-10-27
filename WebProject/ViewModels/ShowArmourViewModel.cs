using System.ComponentModel.DataAnnotations;
using WebProject.Data.Enums;

namespace WebProject.ViewModels
{
    public class ShowArmourViewModel
    {

        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Health")]
        public int ArmourHealth { get; set; }
    }
}
