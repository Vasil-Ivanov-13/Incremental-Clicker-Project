using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebProject.Data.Enums;
using WebProject.Data.Models;

namespace WebProject.Data.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasData(
                new Player
                {
                    Id = 1,
                    Name = "JohnTestSouls",
                    CharacterType = ClassEnums.Basic,
                    Hitpoints = 50,
                    Strength = 1,
                    Level = 1,
                    Gold = 0,
                    Experience = 0,
                    
                }
                );
        }
    }
}
