using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDelivery.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public string? Provider { get; set; }         
        public string? ProviderKey { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string NationalID { get; set; } = string.Empty;
        public string? CodeHashOtp { get; set; } = string.Empty;
        public DateTimeOffset? OtpExpiryTime { get; set; }
        public bool? OtpIsUsed { get; set; } = false;
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}