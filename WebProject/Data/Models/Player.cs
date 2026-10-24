using System.ComponentModel.DataAnnotations;
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

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public int? WeaponId { get; set; }
    public int? ArmorId { get; set; }















}
