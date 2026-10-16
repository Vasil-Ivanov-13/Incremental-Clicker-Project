using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebProject.Data.Models;

namespace WebProject.Data.Configurations
{
    public class EnemyConfiguration : IEntityTypeConfiguration<Enemy>
    {
        public void Configure(EntityTypeBuilder<Enemy> builder)
        {
            builder.HasData(
                new Enemy
                {
                    Id = 1,
                    Hitpoints = 10,
                    DamagePoints = 2,
                    Level = 1,
                    IsAlive = true
                },
                new Enemy
                {
                    Id = 2,
                    Hitpoints = 15,
                    DamagePoints = 3,
                    Level = 2,
                    IsAlive = true
                }
                ,
                new Enemy
                {
                    Id = 3,
                    Hitpoints = 20,
                    DamagePoints = 4,
                    Level = 3,
                    IsAlive = true
                }
                ,
                new Enemy
                {
                    Id = 4,
                    Hitpoints = 40,
                    DamagePoints = 5,
                    Level = 4,
                    IsAlive = true
                }
                );
        }
    }
}

    

