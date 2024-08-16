namespace Utilities.Core.UtilityApplication.DTOs.Mail
{
    public class ResetPasswordDTO
    {
        public MailCredentialDTO MailCredential { get; set; }

        public MailOptionDTO MailOption { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public string ResetToken { get; set; }

        public string MainCompanyName { get; set; }
    }
}