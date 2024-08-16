using GCharge.Domain.Entities.Definitions;
using Microsoft.AspNetCore.Identity;

namespace GCharge.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenEndDate { get; set; }

        public string? ProfileImagePath { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<UserChargeTag> UserChargeTags { get; set; }
        
    }
}