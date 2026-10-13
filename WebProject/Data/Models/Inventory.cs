using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Data.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public int PlayerGold { get; set; } = 0;

        [Required]
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; } 

        
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();


        [Required]

        public virtual Player Player { get; set; } = null!;
    }
}
