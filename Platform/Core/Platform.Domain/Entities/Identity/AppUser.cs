using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Platform.Domain.Entities.Identity
{
    public class AppUser: IdentityUser<string>
    {
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(50)]
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenEndDate { get; set; }

        [MaxLength(256)]
        public string? ProfileImagePath { get; set; }

        public bool IsDeleted { get; set; }
    }
}
