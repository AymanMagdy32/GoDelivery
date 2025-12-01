

using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GoDelivery.Configuration ; 

public class PaymentTransactionConfig : IEntityTypeConfiguration<PaymentTransaction>
{
    public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
    {
   builder.HasKey(p => p.Id);

            // Amount
            builder.Property(p => p.Amount)
                   .IsRequired()
                   .HasPrecision(18, 2); // recommended for money

            // Currency
            builder.Property(p => p.Currency)
                   .IsRequired()
                   .HasMaxLength(10)
                   .HasDefaultValue("USD");

            // Payment Method (Enum)
            builder.Property(p => p.Method)
                   .HasConversion<string>()  // store enum as string
                   .IsRequired();

            // Status
            builder.Property(p => p.Status)
                   .HasMaxLength(50);

            // Gateway IDs
            builder.Property(p => p.GatewayTransactionId)
                   .HasMaxLength(200);

            builder.Property(p => p.GatewayResponse)
                   .HasMaxLength(2000);

            // Timestamps
            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // -------------------------------------------
            // Relationship: PaymentTransaction → Customer
            // (Many Transactions per Customer)
            // -------------------------------------------
            builder.HasOne(p => p.Customer)
                   .WithMany(c => c.PaymentTransactions)
                   .HasForeignKey(p => p.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
    }
    }

