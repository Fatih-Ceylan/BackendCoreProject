using AutoMapper;
using GControl.Application.Abstractions.Mail;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Identity.Employee.SendPasswordWithMail
{

    public class SendPasswordWithMailHandler : IRequestHandler<SendPasswordWithMailRequest, SendPasswordWithMailResponse>
    {
        readonly IPasswordRemakeWriteRepository _passwordRemakeWriteRepository;
        readonly IPasswordRemakeReadRepository _passwordRemakeReadRepository;
        readonly IMailService _mailService;
        readonly IMapper _mapper;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IConfiguration _configuration;

        public SendPasswordWithMailHandler(IPasswordRemakeWriteRepository passwordRemakeWriteRepository, IMailService mailService, IMapper mapper, IPasswordRemakeReadRepository passwordRemakeReadRepository, IEmployeeReadRepository employeeReadRepository, IConfiguration configuration)
        {
            _passwordRemakeWriteRepository = passwordRemakeWriteRepository;
            _mailService = mailService;
            _mapper = mapper;
            _passwordRemakeReadRepository = passwordRemakeReadRepository;
            _employeeReadRepository = employeeReadRepository;
            _configuration = configuration;
        }

        public async Task<SendPasswordWithMailResponse> Handle(SendPasswordWithMailRequest request, CancellationToken cancellationToken)
        {
            var existingEmail = await _employeeReadRepository.GetByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                return new SendPasswordWithMailResponse
                {
                    StatusCode = "404"
                };
            }

            var verificationCode = GenerateRandomNumeric();

            // Şifre sıfırlama talebini veritabanına kaydet
            var passwordRemake = _mapper.Map<T.PasswordRemake>(request);
            passwordRemake.CreatedDate = DateTime.Now;
            passwordRemake.Token = verificationCode;

            var existingPasswordRemake = await _passwordRemakeReadRepository.GetByTokenAsync(passwordRemake.Token);
            if (existingPasswordRemake != null)
            {
                _passwordRemakeWriteRepository.HardDeleteById(existingPasswordRemake.Id.ToString());
            }

            passwordRemake = await _passwordRemakeWriteRepository.AddAsync(passwordRemake);
            await _passwordRemakeWriteRepository.SaveAsync();

            // E-posta içeriğini oluştur
            var mailOption = new MailVM
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
                                 <img src='cid:company_logo' alt='logo' style='display: block; margin-left: auto; margin-right: auto;' height='80' />
                              </div>
                          </body>
                          </html>",
            };

            //// Logo dosyasını önbelleğe al
            //var imagePath = @"C:/Users/fatih.ceylan/Desktop/gcrm-3.jpg";
            //var cachePath = @"C:/Users/fatih.ceylan/Desktop/gcrm-3.jpg.cache";
            //CacheImage(imagePath, cachePath);
            //// E-posta gövdesine logo eklemek için MIME parçası oluştur
            //var imageBytes = File.ReadAllBytes(cachePath);
            //var storageURL = _configuration["Storage:BaseStorageUrl"];
            //var companyDetail = _companyReadRepository.GetAllDeletedStatusDesc(false).FirstOrDefault(c => c.Id == Guid.Parse(employee.CompanyId.ToString()));
            //var imageUrl = $"{storageURL}{companyDetail.LogoPath}";

            //var attachments = new List<Attachment> { new Attachment { ContentBytes = imageBytes, Filename = "company_logo.png", ContentType = "image/png" } };
            //mailOption.Attachments = attachments;
            // E-postayı gönder
            await _mailService.SendEMmailAsync(mailOption);
            // Yanıt oluştur
            var createdResponse = _mapper.Map<SendPasswordWithMailResponse>(passwordRemake);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();
            createdResponse.StatusCode = "200";
            createdResponse.VerificationCode = passwordRemake.Token;
            return createdResponse;
        }

        // Logo dosyasını önbelleğe alma işlemi
        private void CacheImage(string sourcePath, string cachePath)
        {
            if (!File.Exists(cachePath))
            {
                File.Copy(sourcePath, cachePath);
            }
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
