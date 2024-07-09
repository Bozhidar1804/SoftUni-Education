using Microsoft.EntityFrameworkCore;

using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        // We use the empty constructor when we develop the application and test it on our local PC
        public FootballBettingContext()
        {

        }

        // Used by Judge
        // Loading of the DbContext with Dependency Injection -> In real app it is useful
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        // Connection configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Set default connection string
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        // Fluent API and Entities configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}