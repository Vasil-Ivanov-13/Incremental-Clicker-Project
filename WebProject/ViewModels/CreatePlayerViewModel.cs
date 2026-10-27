using System.ComponentModel.DataAnnotations;
using WebProject.Data.Enums;
using WebProject.Data.Models;
using static WebProject.Common.EntityValidations;

namespace WebProject.ViewModels
{
    public class CreatePlayerViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(PlayerNameMaxLength, MinimumLength = PlayerNameMinLength)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(ClassEnums))]
        [Display(Name = "Class")]

        public ClassEnums CharacterClass { get; set; }
    }
}
