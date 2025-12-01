using GoDelivery.Enums;
using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoDelivery.Configuration
{
    public class ShipmentStatusHistoryConfig : IEntityTypeConfiguration<ShipmentStatusHistory>
    {
        public void Configure(EntityTypeBuilder<ShipmentStatusHistory> builder)
        {
            // Primary Key
            builder.HasKey(h => h.Id);

            // Indexes for faster filtering
            builder.HasIndex(h => h.ShipmentId);
            builder.HasIndex(h => h.ChangedAt);

            // Enum conversion for OldStatus
            builder.Property(h => h.OldStatus)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();

            // Enum conversion for NewStatus
            builder.Property(h => h.NewStatus)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();

            // Note: optional
            builder.Property(h => h.Note)
                   .HasMaxLength(1000);

            // ChangedAt timestamp
            builder.Property(h => h.ChangedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Relationship: Many history records → One Shipment
            builder.HasOne(h => h.Shipment)
                   .WithMany(s => s.StatusHistory)
                   .HasForeignKey(h => h.ShipmentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ChangedBy : optional AppUser reference (if exists in your system)
            builder.HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(h => h.ChangedByAppUserId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
