using System.ComponentModel.DataAnnotations;

namespace WebProject.Data.Models
{
    public class Enemy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Hitpoints { get; set; }

        [Required]
        public int DamagePoints { get; set; }

        [Required]
        public int Level { get; set; } = 1;

        [Required]

        public bool IsAlive { get; set; } = true;

    }
}
