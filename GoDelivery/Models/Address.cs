namespace GoDelivery.Models
{
    


public class Address
    {
         public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }         
        public Customer? Customer { get; set; }
        public string Governorate { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    }



}