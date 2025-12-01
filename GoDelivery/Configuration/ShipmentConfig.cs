using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoDelivery.Configuration
{
    public class ShipmentConfig : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            // Primary Key
            builder.HasKey(s => s.Id);

            // Tracking Number
            builder.Property(s => s.TrackingNumber)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(s => s.TrackingNumber)
                   .IsUnique();

            // Shipment dimensions
            builder.Property(s => s.WeightKg)
                   .IsRequired()
                   .HasPrecision(10, 2);

            builder.Property(s => s.LengthCm)
                   .HasPrecision(10, 2);

            builder.Property(s => s.WidthCm)
                   .HasPrecision(10, 2);

            builder.Property(s => s.HeightCm)
                   .HasPrecision(10, 2);

            // Package & shipment type
            builder.Property(s => s.PackageType)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.ShipmentType)
                   .IsRequired()
                   .HasMaxLength(100);

            // Enum conversions
            builder.Property(s => s.WhoPays)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(s => s.PaymentMethod)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(s => s.Status)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();

            // Price & payment
            builder.Property(s => s.Price)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(s => s.IsPaid)
                   .HasDefaultValue(false);

            // Cancel details
            builder.Property(s => s.CancelReason)
                   .HasMaxLength(500);

            // CreatedAt timestamp
            builder.Property(s => s.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // -----------------------------------------
            // RELATIONSHIPS
            // -----------------------------------------

            // 1️⃣ Sender (Customer → Shipment)
            builder.HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(s => s.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 2️⃣ Recipient (Customer → Shipment)
            builder.HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(s => s.RecipientId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 3️⃣ Sender Address
            builder.HasOne<Address>()
                   .WithMany()
                   .HasForeignKey(s => s.SenderAddressId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 4️⃣ Recipient Address
            builder.HasOne<Address>()
                   .WithMany()
                   .HasForeignKey(s => s.RecipientAddressId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 5️⃣ Assigned Representative (optional)
            builder.HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(s => s.AssignedRepresentativeId)
                   .OnDelete(DeleteBehavior.SetNull);

            // 6️⃣ Pricing Rule (optional many-to-one)
            builder.HasOne(s => s.PricingRule)
                   .WithMany(p => p.Shipments)
                   .HasForeignKey(s => s.PricingRuleId)
                   .OnDelete(DeleteBehavior.SetNull);

     
        }
    }
}
