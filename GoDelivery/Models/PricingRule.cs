using GoDelivery.Enums;

namespace GoDelivery.Models
{
     public class PricingRule
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public PricingScope Scope { get; set; } = PricingScope.Internal;
        public decimal? MinWeightKg { get; set; }
        public decimal? MaxWeightKg { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? PricePerKg { get; set; }
        public decimal? ExtraSizePrice { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }
        public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    }




}