using BaseProject.Domain.Entities.Identity;

namespace BaseProject.Domain.Entities.Definitions
{
    public class MailCredential: B_BaseEntity
    {
        public Guid? CompanyId { get; set; }

        public Guid? BranchId { get; set; }

        public string? UserId { get; set; }
        
        public string From { get; set; }

        public string FromPassword { get; set; }

        public string DisplayName { get; set; }

        public int Port { get; set; }

        public string Host { get; set; }

        public bool EnableSsl { get; set; }

        public bool IsVerified { get; set; }

        public bool IsActive { get; set; }

        public Branch? Branch { get; set; }

        public AppUser? User { get; set; }
    }
}