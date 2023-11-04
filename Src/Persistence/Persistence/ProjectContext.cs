using Domain.DomainClass;
using Microsoft.EntityFrameworkCore;

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



            modelBuilder.Entity<Airport>().OwnsOne(pi => pi.airport_name, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("airport_name")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();
            });

            modelBuilder.Entity<Airport>().OwnsOne(pi => pi.latitude, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("latitude")
                .IsRequired();
            });

            modelBuilder.Entity<Airport>().OwnsOne(pi => pi.longitude, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("longitude")
                .IsRequired();
            });




            modelBuilder.Entity<Flight>().OwnsOne(pi => pi.airportname, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("airportname")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();
            });

        }
    }
}
