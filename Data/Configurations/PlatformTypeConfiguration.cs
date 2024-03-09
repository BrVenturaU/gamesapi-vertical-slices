using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Data.Configurations
{
    public class PlatformTypeConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.HasData(
                new Platform
                {
                    Id = 1,
                    Name = "Xbox Series X",
                    Manufacturer = "Microsoft"
                },
                new Platform
                {
                    Id = 2,
                    Name = "PlayStation 5",
                    Manufacturer = "Sony"
                },
                new Platform
                {
                    Id = 3,
                    Name = "Nintendo Switch",
                    Manufacturer = "Nintendo"
                }
            );
        }
    }
}
