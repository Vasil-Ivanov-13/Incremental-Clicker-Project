using System.ComponentModel.DataAnnotations;
using static WebProject.Common.EntityValidations;
namespace WebProject.ViewModels
{
    public class RenameViewModel
    {

            [Required(ErrorMessage = "Please enter a name.")]
            [StringLength(ItemNameMaxLength, MinimumLength = 3)]
            [Display(Name = "New name")]
            public string NewName { get; set; } = null!;
        
    }
}
