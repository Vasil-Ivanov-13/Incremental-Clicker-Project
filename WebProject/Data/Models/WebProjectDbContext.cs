using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProject.Data.Configurations;
namespace WebProject.Data.Models
{
    public class WebProjectDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebProjectDbContext(DbContextOptions<WebProjectDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Player> Players { get; set; } = null!;

        public virtual DbSet<Enemy> Enemies { get; set; } = null!;

        public virtual DbSet<WeaponItem> WeaponItems { get; set; } = null!;
        public virtual DbSet<ArmourItem> ArmourItems { get; set; } = null!;
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.WeaponItem)
                .WithOne(w => w.Player)
                .HasForeignKey<WeaponItem>(w => w.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.ArmourItem)
                .WithOne(a => a.Player)
                .HasForeignKey<ArmourItem>(a => a.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Player)
                .WithOne(p => p.User)
                .HasForeignKey<Player>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);




            modelBuilder.ApplyConfiguration(new EnemyConfiguration());


        }

      
    }
}
