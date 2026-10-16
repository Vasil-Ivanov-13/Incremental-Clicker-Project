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
    public int DamagePoints { get; set; }

    [Required]
    public int Level { get; set; } = 1;

    [Required]

    public int ExperiencePoints { get; set; } = 0;

    [Required]

    public bool IsAlive { get; set; } = true;

    [Required]

    public int TalentPoints { get; set; } = 0;

    [Required]

    public virtual Inventory Inventory { get; set; } = null!;













}
