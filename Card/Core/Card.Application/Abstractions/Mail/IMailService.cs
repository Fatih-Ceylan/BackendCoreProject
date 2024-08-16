using Card.Application.VMs;

namespace Card.Application.Abstractions.Mail
{
    public interface IMailService
    {
        Task SendEMmailAsync(MailVM mailOption);
    }
}
