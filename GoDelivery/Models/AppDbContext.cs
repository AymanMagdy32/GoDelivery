using System.Reflection;
using GoDelivery.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoDelivery.Models
{
    public class AppDbContext 
        : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<EmailLog> EmailLogs { get; set; } = default!;
        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; } = default!;
        public DbSet<PricingRule> PricingRules { get; set; } = default!;
        public DbSet<Shipment> Shipments { get; set; } = default!;
        public DbSet<ShipmentStatusHistory> ShipmentStatusHistories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
