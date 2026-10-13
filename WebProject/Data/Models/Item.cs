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
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        public int Price { get; set; }

        /*Add objects for shop and player inventory */

        
        [ForeignKey(nameof(Shop))]
        public int? ShopId { get; set; }

        
        public virtual Shop Shop { get; set; } = null!;


        [ForeignKey(nameof(Inventory))]
        public int? InventoryId { get; set; }

        
        public virtual Inventory? Inventory { get; set; }
    }
}
