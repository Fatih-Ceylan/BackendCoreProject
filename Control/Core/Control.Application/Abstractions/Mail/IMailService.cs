using GControl.Application.VMs.Definitions;

namespace GControl.Application.Abstractions.Mail
{
    public interface IMailService
    {
        Task SendEMmailAsync(MailVM mailOption);
    }
}
