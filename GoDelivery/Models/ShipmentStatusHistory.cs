using GoDelivery.Models;

namespace GoDelivery.Enums
{
    public class ShipmentStatusHistory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ShipmentId { get; set; }
        public Shipment? Shipment {get; set; }
        public ShipmentStatus OldStatus { get; set; }
        public ShipmentStatus NewStatus { get; set; }
        public Guid? ChangedByAppUserId { get; set; }
        public string? Note { get; set; }
        public DateTimeOffset ChangedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}