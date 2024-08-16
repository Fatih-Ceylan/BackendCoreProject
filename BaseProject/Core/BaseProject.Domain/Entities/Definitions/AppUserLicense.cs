using BaseProject.Domain.Entities.Identity;

namespace BaseProject.Domain.Entities.Definitions
{
    public class AppUserLicense : B_BaseEntity
    {
        public string AppUserId { get; set; }

        public Guid LicenseId { get; set; }

        public bool IsInUse { get; set; }

        public AppUser AppUser { get; set; }
    }
}