using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProject.Data.Configurations;
namespace WebProject.Data.Models
{
    public class WebProjectDbContext : IdentityDbContext<IdentityUser>
    {
        public WebProjectDbContext(DbContextOptions<WebProjectDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Player> Players { get; set; } = null!;

        // public virtual DbSet<Inventory> Inventories { get; set; } = null!;

        // public virtual DbSet<Item> Items { get; set; } = null!;

        //public virtual DbSet<Shop> Shops { get; set; } = null!;

        public virtual DbSet<Enemy> Enemies { get; set; } = null!;

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .HasOne(e => e.Inventory)
                .WithOne(a => a.Player)
                .HasForeignKey<Inventory>(e => e.PlayerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        

        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new EnemyConfiguration());


        }
    }
}
