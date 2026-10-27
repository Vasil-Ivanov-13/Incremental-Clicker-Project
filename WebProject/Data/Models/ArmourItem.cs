using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebProject.Common.EntityValidations;
namespace WebProject.Data.Models

{
    public class ArmourItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ItemNameMaxLength)]

        public string ItemName { get; set; } = null!;

        [Range(ItemMinHealth, ItemMaxHealth)]

        public int HealthPoints { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        public virtual Player? Player { get; set; }

    }
}
