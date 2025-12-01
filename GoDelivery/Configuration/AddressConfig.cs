

using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GoDelivery.Configuration ; 

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);

            // Required string fields with max lengths
            builder.Property(a => a.Governorate)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.District)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Street)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(a => a.BuildingNumber)
                   .HasMaxLength(10);

            builder.Property(a => a.PostalCode)
                   .HasMaxLength(20);

            // CreatedAt default value
            builder.Property(a => a.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Relationship: Address → Customer (Many-to-One)
            builder.HasOne(a => a.Customer)
                   .WithMany(c => c.Addresses)
                   .HasForeignKey(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
    }
    }

