

using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GoDelivery.Configuration ; 

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
    // Primary Key
            builder.HasKey(e => e.Id);

            // Governorate field
            builder.Property(e => e.Governorate)
                   .IsRequired()
                   .HasMaxLength(100);

            // HireDate default value
            builder.Property(e => e.HireDate)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // -------------------------------------------
            // One-to-One: Employee ↔ ApplicationUser
            // -------------------------------------------
            builder.HasOne(e => e.AppUser)
                   .WithOne(u => u.Employee)
                   .HasForeignKey<Employee>(e => e.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade);
    }
    }

