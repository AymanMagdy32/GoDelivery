using GoDelivery.Enums;

namespace GoDelivery.Models
{
    public class PaymentTransaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; } // fk with customer 
        public Customer? Customer{ get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public PaymentMethod Method { get; set; }
        public string? Status { get; set; } 
        public string? GatewayTransactionId { get; set; }
        public string? GatewayResponse { get; set; } 
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? CompletedAt { get; set; }
    }
}