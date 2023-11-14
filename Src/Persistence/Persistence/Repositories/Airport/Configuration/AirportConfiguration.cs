using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Persistence.Repositories.Airport.Configuration
{

    public class AirportConfiguration : IEntityTypeConfiguration<Domain.DomainClass.Airport>
    {
        public void Configure(EntityTypeBuilder<Domain.DomainClass.Airport> builder)
        {

            builder.OwnsOne(pi => pi.airport_name, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("airport_name")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();
            });

            builder.OwnsOne(pi => pi.latitude, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("latitude")
                .IsRequired();
            });

            builder.OwnsOne(pi => pi.longitude, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("longitude")
                .IsRequired();
            });

        }
    }
}
