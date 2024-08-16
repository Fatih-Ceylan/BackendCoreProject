using Card.Application.Abstractions.Mail;
using Card.Application.Abstractions.SmtpSettings;
using Card.Application.VMs;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Card.Persistence.Mail
{
    public class MailService : IMailService
    {
        readonly SmtpSettings _smtpSettings;

        public MailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEMmailAsync(MailVM mailOption)
        {
            try
            {

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpSettings.DisplayName, _smtpSettings.From));

                foreach (var toEmail in mailOption.To)
                {
                    message.To.Add(new MailboxAddress("", toEmail));
                }

                message.Subject = mailOption.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = mailOption.Body;
                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.EnableSsl);
                    await client.AuthenticateAsync(_smtpSettings.From, _smtpSettings.FromPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString(), ex);
            }
        }
    }
}
