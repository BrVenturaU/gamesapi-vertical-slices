using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VerticalSliceArchitecture.Data.Configurations;
using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
