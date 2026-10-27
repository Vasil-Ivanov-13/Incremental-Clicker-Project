using System.ComponentModel.DataAnnotations;
using static WebProject.Common.EntityValidations;
namespace WebProject.ViewModels
{
    public class CraftWeaponViewModel
    {
        [Required]
        [StringLength(ItemNameMaxLength, MinimumLength = ItemNameMinLength)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; } = null!;

    }
}
