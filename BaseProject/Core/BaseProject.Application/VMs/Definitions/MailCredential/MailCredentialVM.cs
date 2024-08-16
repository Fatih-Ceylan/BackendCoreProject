using Utilities.Core.UtilityApplication.VMs;

namespace BaseProject.Application.VMs.Definitions.MailCredential
{
    public class MailCredentialVM: BaseVM
    {
        public string? CompanyId { get; set; }

        public string? CompanyName { get; set; }

        public string? BranchId { get; set; }

        public string? BranchName { get; set; }

        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string From { get; set; }

        public string FromPassword { get; set; }

        public string DisplayName { get; set; }

        public int Port { get; set; }

        public string Host { get; set; }

        public bool EnableSsl { get; set; }

        public bool IsVerified { get; set; }

        public bool IsActive { get; set; }
    }
}