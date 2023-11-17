using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Persistence.Repositories.Flight.Configuration
{

    public class FlightConfiguration : IEntityTypeConfiguration<Domain.DomainClass.Flight>
    {
        public void Configure(EntityTypeBuilder<Domain.DomainClass.Flight> builder)
        {
            builder.HasKey(k => k.Id);

            builder.OwnsOne(pi => pi.airportname, builder =>
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
