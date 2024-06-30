using Microsoft.EntityFrameworkCore;
using Roller.Domain.Entities;
using Roller.Infrastructure.Database.Configuration;



namespace Roller.Infrastructure.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Roll> Rolls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RollConfiguration());
        }
    }
}