using Domain.DomainClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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


            modelBuilder.Entity<Airport>().Property(c => c.phone_number)
              .HasMaxLength(500);
        }
    }
}
