using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoDelivery.Configuration
{
    public class PricingRuleConfig : IEntityTypeConfiguration<PricingRule>
    {
        public void Configure(EntityTypeBuilder<PricingRule> builder)
        {
            // Primary Key
            builder.HasKey(p => p.Id);

            // Name
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            // Enum stored as string
            builder.Property(p => p.Scope)
                   .HasConversion<string>()
                   .IsRequired()
                   .HasMaxLength(50);

            // Weight ranges
            builder.Property(p => p.MinWeightKg)
                   .HasPrecision(10, 2);

            builder.Property(p => p.MaxWeightKg)
                   .HasPrecision(10, 2);

            // Pricing amounts
            builder.Property(p => p.BasePrice)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(p => p.PricePerKg)
                   .HasPrecision(18, 2);

            builder.Property(p => p.ExtraSizePrice)
                   .HasPrecision(18, 2);

            // Active flag
            builder.Property(p => p.IsActive)
                   .HasDefaultValue(true);

            // Timestamps
            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.UpdatedAt)
                   .IsRequired(false);

            // Relationship: PricingRule (1) → (Many) Shipments
            builder.HasMany(p => p.Shipments)
                   .WithOne(s => s.PricingRule)
                   .HasForeignKey(s => s.PricingRuleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
