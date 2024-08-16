using GControl.Application.Abstractions.Mail;
using GControl.Application.Abstractions.SmtpSettings;
using GControl.Application.VMs.Definitions;
using Microsoft.Extensions.Options;
using MimeKit;

namespace GControl.Persistence.Mail
{
    public class MailService : IMailService
    {
        readonly SmtpSettings _smtpSettings;

        public MailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        //public async Task SendEMmailAsync(MailVM mailOption)
        //{
        //    try
        //    {
        //        var message = new MimeMessage();
        //        message.From.Add(new MailboxAddress(_smtpSettings.DisplayName, _smtpSettings.From));

        //        foreach (var toEmail in mailOption.To)
        //        {
        //            message.To.Add(new MailboxAddress("", toEmail));
        //        }
        //        message.Subject = mailOption.Subject;

        //        var builder = new BodyBuilder();
        //        builder.HtmlBody = mailOption.Body;
        //        message.Body = builder.ToMessageBody();

        //        using (var client = new MailKit.Net.Smtp.SmtpClient())
        //        {
        //            await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.EnableSsl);
        //            await client.AuthenticateAsync(_smtpSettings.From, _smtpSettings.FromPassword);
        //            await client.SendAsync(message);
        //            await client.DisconnectAsync(true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message.ToString(), ex);
        //    }
        //}

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

                var builder = new BodyBuilder
                {
                    HtmlBody = mailOption.Body
                };

                if (mailOption.Attachments != null)
                {
                    foreach (var attachment in mailOption.Attachments)
                    {
                        // Check if the attachment is the company logo and add it as a linked resource
                        if (attachment.Filename == "company_logo.png")
                        {
                            var logo = builder.LinkedResources.Add(attachment.Filename, attachment.ContentBytes, ContentType.Parse(attachment.ContentType));
                            logo.ContentId = MimeKit.Utils.MimeUtils.GenerateMessageId();

                            // Update HTML body to use the linked resource
                            builder.HtmlBody = builder.HtmlBody.Replace("cid:company_logo", $"cid:{logo.ContentId}");
                        }
                        else
                        {
                            builder.Attachments.Add(attachment.Filename, attachment.ContentBytes, ContentType.Parse(attachment.ContentType));
                        }
                    }
                }

                message.Body = builder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.EnableSsl);
                    await client.AuthenticateAsync(_smtpSettings.From, _smtpSettings.FromPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to send email: " + ex.Message, ex);
            }
        }
    }
}
