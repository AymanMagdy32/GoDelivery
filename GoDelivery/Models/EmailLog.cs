


namespace GoDelivery.Models
{
    
public class EmailLog
    {
        
       public Guid Id { get; set; } = Guid.NewGuid();
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public Guid? ShipmentId { get; set; }
        public Guid? AppUserId { get; set; }
        public DateTimeOffset? SentAt { get; set; }
        public string Status { get; set; } = "Pending";
        public int RetryCount { get; set; } = 0;
        public string? HangfireJobId { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    }

}