using Utilities.Core.UtilityApplication.DTOs.Mail;

namespace Utilities.Core.UtilityApplication.Abstractions.Services.Mail
{
    public interface IMailService
    {
        Task<string> SendEMmailAsync(MailCredentialDTO mailCredential, MailOptionDTO mailOption);

        Task<MailCredentialDTO> GetStaticMailCredential();
    }
}