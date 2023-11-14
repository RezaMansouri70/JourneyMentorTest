using Domain.DomainClass;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Airport.Configuration;
using Persistence.Repositories.Flight.Configuration;

namespace Persistence
{

    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AirportConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            // Or  modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
