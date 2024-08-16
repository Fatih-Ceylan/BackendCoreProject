using MediatR;
using System.Text;
using Utilities.Core.UtilityApplication.Abstractions.Services.Mail;
using Utilities.Core.UtilityApplication.DTOs.Mail;

namespace GCharge.Application.Features.Commands.Identity.AppUser.SendEmailToken
{
    public class SendEmailTokenHandler : IRequestHandler<SendEmailTokenRequest, SendEmailTokenResponse>
    {
        readonly IMailService _mailService;
       
        public SendEmailTokenHandler(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task<SendEmailTokenResponse> Handle(SendEmailTokenRequest request, CancellationToken cancellationToken)
        {
            var mailCredantial = await _mailService.GetStaticMailCredential();

            MailOptionDTO mailOption = new();
            mailOption.To = new string[] { request.Email };

            return new()
            {
                Message = await SendEMailTokenAsync(mailCredantial, mailOption),
            };
        }

        public async Task<string> SendEMailTokenAsync(MailCredentialDTO mailCredantial, MailOptionDTO mailOption)
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 1000000);

            StringBuilder mail = new();
            mail.AppendLine("Merhaba,<br><br>Mail doğrulama kodunuz<br><br><strong><h2>");
            mail.Append(randomNumber);
            mail.Append("</h2></strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen maili dikkate almayınız.</span><br>Saygılarımızla...<br><br><br>");
            mail.Append("<img src=\"http://10.0.0.96:81/Company-Files/fotec.jpg\" width=\"200\" height=\"150\" alt=\"Şirket Logosu\"><br><h2>");
            mail.Append("FOTEC AŞ.</h2>");

            mailOption.Subject = "Email Doğrulama Şifresi";
            mailOption.Body = mail.ToString();

            return await _mailService.SendEMmailAsync(mailCredantial, mailOption);
        }
    }
}