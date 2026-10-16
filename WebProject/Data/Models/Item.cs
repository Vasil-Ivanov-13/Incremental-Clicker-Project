using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Data.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        /*Add item stats */

        [Required]
        public double LevelMultiplier { get; set; } = 1.8;

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        public int Price { get; set; }    

        [ForeignKey(nameof(Shop))]
        public int? ShopId { get; set; }
        public virtual Shop? Shop { get; set; }


        [ForeignKey(nameof(Inventory))]
        public int? InventoryId { get; set; }

        
        public virtual Inventory? Inventory { get; set; }
    }
}
