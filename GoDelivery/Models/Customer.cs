namespace GoDelivery.Models
{

 public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Gender { get; set; }

        public Guid AppUserId { get; set; } // fk for the AppUser 
         public ApplicationUser? AppUser { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>(); // many to one  
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>(); // many to one

    }



}