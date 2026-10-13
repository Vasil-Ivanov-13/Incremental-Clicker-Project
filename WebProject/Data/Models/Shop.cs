using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Data.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        /* Figure out how items will work with shop list later TODO!
                [Required]
                [ForeignKey(nameof(Items))]
                public int itemId { get; set; }
                */
        
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
