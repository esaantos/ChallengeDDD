using Challenge.Core.Entities;
using Challenge.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Associate> Associates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssociateConfigurations).Assembly);
        }
    }
}
