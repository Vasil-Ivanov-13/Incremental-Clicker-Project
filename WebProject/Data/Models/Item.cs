using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Data.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]

        public string ItemName { get; set; } = null!;

        // dice roll adding mechanic for damage?

        
        [Range(-5, 10)]
        public int? DamagePoints { get; set; }

        
        [Range(1, 2)]

        public double? CritModifier { get; set; } = 1;

        [Range(1, 30)]

        public int? HealthPoints { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        public virtual Player? Player { get; set; }
    }
}
