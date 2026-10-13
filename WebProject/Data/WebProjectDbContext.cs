using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProject.Data.Models;
namespace WebProject.Data
{
    public class WebProjectDbContext : DbContext
    {
        public WebProjectDbContext(DbContextOptions<WebProjectDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Player> Players { get; set; } = null!;

        public virtual DbSet<Inventory> Inventories { get; set; } = null!;

        public virtual DbSet<Item> Items { get; set; } = null!;

        public virtual DbSet<Shop> Shops { get; set; } = null!;

        public virtual DbSet<Enemy> Enemies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .HasOne(e => e.Inventory)
                .WithOne(a => a.Player)
                .HasForeignKey<Inventory>(e => e.PlayerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        




    }
}
