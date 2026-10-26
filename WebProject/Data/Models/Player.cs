using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebProject.Data.Enums;
namespace WebProject.Data.Models;
using static Common.EntityValidations;



public class Player
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PlayerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public ClassEnums CharacterType { get; set; } = 0;

    [Required]
    public int Hitpoints { get; set; }

    [Required]
    public int Strength { get; set; } = 1;

    [Required]
    public int Level { get; set; } = 1;

    [Required]
    public int Experience { get; set; } = 0;

    [Required]
    public int Gold { get; set; } = 0;

    [Required]
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public virtual WeaponItem? WeaponItem { get; set; }
    public virtual ArmourItem? ArmourItem { get; set; }
    public virtual ApplicationUser User { get; set; } = null!;

}
