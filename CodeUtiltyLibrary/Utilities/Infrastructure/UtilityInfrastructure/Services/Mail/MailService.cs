using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Utilities.Core.UtilityApplication.Abstractions.Services.Mail;
using Utilities.Core.UtilityApplication.DTOs.Mail;

namespace Utilities.Infrastructure.UtilityInfrastructure.Services.Mail
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<MailCredentialDTO> GetStaticMailCredential()
        {
            MailCredentialDTO mailCredantial = new();
            mailCredantial.Host = _configuration["SmtpSettings:Host"];
            mailCredantial.Port = Convert.ToInt32(_configuration["SmtpSettings:Port"]);
            mailCredantial.EnableSsl = Convert.ToBoolean(_configuration["SmtpSettings:EnableSsl"]);
            mailCredantial.From = _configuration["SmtpSettings:From"];
            mailCredantial.FromPassword = _configuration["SmtpSettings:FromPassword"];
            mailCredantial.DisplayName = _configuration["SmtpSettings:DisplayName"];

            return mailCredantial;
        }

        public async Task<string> SendEMmailAsync(MailCredentialDTO mailCredantial, MailOptionDTO mailOption)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(mailCredantial.DisplayName, mailCredantial.From));

                foreach (var toEmail in mailOption.To)
                {
                    message.To.Add(new MailboxAddress("", toEmail));
                }

                message.Subject = mailOption.Subject;

                var builder = new BodyBuilder();
                if (mailOption.IsBodyHtml)
                {
                    builder.HtmlBody = mailOption.Body;
                }
                else
                {
                    builder.TextBody = mailOption.Body;
                }
                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(mailCredantial.Host, mailCredantial.Port, mailCredantial.EnableSsl);
                    await client.AuthenticateAsync(mailCredantial.From, mailCredantial.FromPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                    return "Mail sent successfully.";
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString(), ex);
            }
        }
    }
}