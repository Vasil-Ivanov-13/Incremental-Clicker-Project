namespace WebProject.ViewModels

{
    using System.ComponentModel.DataAnnotations;
    using static WebProject.Common.EntityValidations;
    public class CraftArmourViewModel
    {
        [Required]
        [StringLength(ItemNameMaxLength, MinimumLength = ItemNameMinLength)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; } = null!;

    }
}
