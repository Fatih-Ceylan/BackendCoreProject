using MediatR;
using Platform.Application.Features.Commands.Outbounds.SendEmailToContacts;
using System.Text;
using Utilities.Core.UtilityApplication.Abstractions.Services.Mail;
using Utilities.Core.UtilityApplication.DTOs.Mail;

namespace Platform.Application.Features.Commands.Outbounds.SendEmail
{
    public class SendEmailToContactsHandler : IRequestHandler<SendEmailToContactsRequest, SendEmailToContactsResponse>
    {
        readonly IMailService _mailService;

        public SendEmailToContactsHandler(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task<SendEmailToContactsResponse> Handle(SendEmailToContactsRequest request, CancellationToken cancellationToken)
        {
            var mailCredantial = await _mailService.GetStaticMailCredential();

            MailOptionDTO mailOption = new();

            SendEmailToContactsResponse response = new();
            response.MessageList = new();

            mailOption.To = new string[] { request.Email };
            var toContactMessage  = await SendEMailAsync(mailCredantial, mailOption, "Mail bilginiz alınmıştır.En kısa sürede sizinle iletişime geçilecektir.", "Bilgilendirme");  
            response.MessageList.Add("For Contact " + toContactMessage);

            mailOption.To = new string[] { mailCredantial.From };
            var toOwnMessage = await SendEMailAsync(mailCredantial, mailOption, $"{request.Email} kişisi iletişim talebinde bulunmuştur.En kısa sürede iletişime geçiniz.", "İletişim Talebi");
            response.MessageList.Add("For Own " + toOwnMessage);

            return response;
        }

        public async Task<string> SendEMailAsync(MailCredentialDTO mailCredantial, MailOptionDTO mailOption, string body, string subject)
        {
            //todo url'i appsettings'den çek
            StringBuilder mail = new();
            mail.AppendLine($"Merhaba,<br><br>{body}<br><br><strong>");
            mail.Append("</strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen maili dikkate almayınız.</span><br>Saygılarımızla...<br><br><br>");
            mail.Append("<img src=\"http://localhost:5000/GModule-Files/prodcloud.png\" width=\"200\" alt=\"Şirket Logosu\"><br>");
            mail.Append("prodcloud firmamızın bir ürünüdür.<br>");
            mail.Append("<h2>GCode İleri Teknoloji Yazılım AŞ.</h2>");

            mailOption.Subject = subject;
            mailOption.Body = mail.ToString();

            return await _mailService.SendEMmailAsync(mailCredantial, mailOption);
        }
    }
}