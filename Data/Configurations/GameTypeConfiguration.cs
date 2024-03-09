using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Data.Configurations
{
    public class GameTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(

                new Game
                {
                    Id = 10,
                    Name = "Horizon Forbidden West",
                    Publisher = "Sony Interactive Entertainment",
                    PlatformId = 2
                },
                new Game
                {
                    Id = 11,
                    Name = "Animal Crossing: New Horizons",
                    Publisher = "Nintendo",
                    PlatformId = 3
                },
                new Game
                {
                    Id = 12,
                    Name = "Halo Infinite",
                    Publisher = "Xbox Game Studios",
                    PlatformId = 1
                }

            );
        }
    }
}
