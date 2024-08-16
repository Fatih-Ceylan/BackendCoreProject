namespace BaseProject.Application.Features.Commands.Definitions.MailCredential.Create
{
    public class CreateMailCredentialResponse
    {
        public string Id { get; set; }

        public string? CompanyId { get; set; }

        public string? BranchId { get; set; }

        public string? UserId { get; set; }

        public string From { get; set; }

        public string DisplayName { get; set; }

        public int Port { get; set; }

        public string Host { get; set; }

        public bool EnableSsl { get; set; }

        public bool IsVerified { get; set; }

        public bool IsActive { get; set; }

        public string Message { get; set; }
    }
}