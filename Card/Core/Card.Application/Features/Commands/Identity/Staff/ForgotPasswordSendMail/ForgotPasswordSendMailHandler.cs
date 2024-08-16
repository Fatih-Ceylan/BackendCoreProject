using AutoMapper;
using Card.Application.Abstractions.Mail;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using Card.Application.VMs;
using MediatR;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Identity.Staff.ForgotPasswordSendMail
{
    public class ForgotPasswordSendMailHandler : IRequestHandler<ForgotPasswordSendMailRequest, ForgotPasswordSendMailResponse>
    {
        readonly IPasswordRemakeWriteRepository _passwordRemakeWriteRepository;
        readonly IPasswordRemakeReadRepository _passwordRemakeReadRepository;
        readonly IMailService _mailService;
        readonly IMapper _mapper;
        readonly IStaffReadRepository _staffReadRepository;

        public ForgotPasswordSendMailHandler(IPasswordRemakeWriteRepository passwordRemakeWriteRepository, IMailService mailService, IMapper mapper, IPasswordRemakeReadRepository passwordRemakeReadRepository, IStaffReadRepository staffReadRepository)
        {
            _passwordRemakeWriteRepository = passwordRemakeWriteRepository;
            _mailService = mailService;
            _mapper = mapper;
            _passwordRemakeReadRepository = passwordRemakeReadRepository;
            _staffReadRepository = staffReadRepository;
        }

        public async Task<ForgotPasswordSendMailResponse> Handle(ForgotPasswordSendMailRequest request, CancellationToken cancellationToken)
        {
            var existingEmail = _staffReadRepository.GetByEmailAsync(request.Email).Result;

            if (existingEmail == null)
            {
                return new()
                {
                    Message = CommandResponseMessage.EmailNotFound.ToString(),
                    StatusCode = "404"
                };
            }
            ;
            var verificationCode = GenerateRandomNumeric();

            T.PasswordRemake passwordRemake = _mapper.Map<T.PasswordRemake>(request);
            passwordRemake.CreatedDate = DateTime.Now;
            passwordRemake.Token = verificationCode;

            var passwordRemakeControl = _passwordRemakeReadRepository.GetByTokenAsync(passwordRemake.Token).Result;

            if (passwordRemakeControl != null)
            {
                _passwordRemakeWriteRepository.HardDeleteById(passwordRemakeControl.Id.ToString());
            }

            passwordRemake = await _passwordRemakeWriteRepository.AddAsync(passwordRemake);

            await _passwordRemakeWriteRepository.SaveAsync();

            MailVM mailOption = new MailVM
            {
                To = new string[] { passwordRemake.Email },
                Subject = "Şifrenizi Yenileyin",
                Body = $@"
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Doğrulama Kodu</title>
</head>
<body>
    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;'>
        <h2>Doğrulama Kodu</h2>
        <p>Merhaba,</p>
        <p>Doğrulama kodunuz aşağıdadır:</p>
        <p style='font-size: 24px; font-weight: bold;'>{verificationCode}</p>
        <p>Bu kodu ilgili alana girerek işleminizi tamamlayabilirsiniz.</p>
        <p>Eğer bu isteği siz yapmadıysanız, bu e-postayı görmezden gelebilirsiniz.</p>
        <p>İyi günler dileriz.</p>
    </div>

    <!-- Resim en altta -->
    <div style='text-align: center; margin-top: 20px;'>
        <img src='https://example.com/images/company_logo.png' alt='Company Logo' style='max-width: 200px;'>
    </div>
</body>
</html>"
            };

            await _mailService.SendEMmailAsync(mailOption);

            var createdResponse = _mapper.Map<ForgotPasswordSendMailResponse>(passwordRemake);

            createdResponse.Message = CommandResponseMessage.Success.ToString();
            createdResponse.StatusCode = "200";
            createdResponse.VerificationCode = passwordRemake.Token;

            return createdResponse;
        }

        private string GenerateRandomNumeric()
        {
            const string chars = "0123456789";
            Random random = new Random();
            StringBuilder builder = new StringBuilder(6);
            for (int i = 0; i < 6; i++)
            {
                builder.Append(chars[random.Next(chars.Length)]);
            }
            return $"{builder.ToString()}";
        }
    }
}
