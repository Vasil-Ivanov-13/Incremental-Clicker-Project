using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebProject.Common.EntityValidations;


namespace WebProject.Data.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ItemNameMaxLength)]

        public string ItemName { get; set; } = null!;

        // dice roll adding mechanic for damage?

        
        [Range(ItemMinDamage, ItemMaxDamage)]
        public int? DamagePoints { get; set; }

        
        

        public int? StrengthModifier { get; set; }

        [Range(ItemMinHealth, ItemMaxHealth)]

        public int? HealthPoints { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        public virtual Player? Player { get; set; }
    }
}
