

using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GoDelivery.Configuration ; 

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

           builder.HasKey(c => c.Id);

            // Gender optional
            builder.Property(c => c.Gender)
                .HasMaxLength(20);

            // Relationship: Customer → AppUser (One-to-One)
             builder.HasOne(c => c.AppUser)               
                    .WithOne(u => u.Customer)              
                    .HasForeignKey<Customer>(c => c.AppUserId)
                    .OnDelete(DeleteBehavior.Cascade);

            // Relationship: Customer → Addresses (One-to-Many)
            builder.HasMany(c => c.Addresses)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship: Customer → PaymentTransactions (One-to-Many)
            builder.HasMany(c => c.PaymentTransactions)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
