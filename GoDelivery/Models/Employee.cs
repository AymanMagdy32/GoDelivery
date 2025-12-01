





namespace GoDelivery.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AppUserId { get; set; }  // fk with the appuser
        public ApplicationUser? AppUser { get; set; }

        public string Governorate { get; set; } = string.Empty;
        public DateTime HireDate { get; set; } = DateTime.UtcNow;
    }
}