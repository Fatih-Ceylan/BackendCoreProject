using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using GControl.Application.Abstractions.Mail;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.Employee.EmployeeCredentials
{
    public class EmployeeCredentialsHandler : IRequestHandler<EmployeeCredentialsRequest, EmployeeCredentialsResponse>
    {
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IMapper _mapper;
        readonly IMailService _mailService;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IConfiguration _configuration;

        public EmployeeCredentialsHandler(
            IEmployeeReadRepository employeeReadRepository,
            IMapper mapper,
            IEmployeeWriteRepository employeeWriteRepository,
            IMailService mailService,
            ICompanyReadRepository companyReadRepository,
            IConfiguration configuration)
        {
            _employeeReadRepository = employeeReadRepository;
            _mapper = mapper;
            _employeeWriteRepository = employeeWriteRepository;
            _mailService = mailService;
            _companyReadRepository = companyReadRepository;
            _configuration = configuration;
        }

        public async Task<EmployeeCredentialsResponse> Handle(EmployeeCredentialsRequest request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.Id);
            var employeeVM = _mapper.Map<T.Employee>(employee);

            var newPassword = GenerateRandomPassword(6);
            employeeVM.Password = HashPassword(newPassword);

            employeeVM = _mapper.Map(request, employeeVM);
            await _employeeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<EmployeeCredentialsResponse>(employeeVM);
            createdResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            if (employee.CompanyId != Guid.Empty)
            {
                var companyDetail = _companyReadRepository.GetAllDeletedStatusDesc(false).FirstOrDefault(c => c.Id == Guid.Parse(employee.CompanyId.ToString()));
                if (companyDetail != null && !string.IsNullOrEmpty(companyDetail.LogoPath))
                {
                    var storageURL = _configuration["Storage:BaseStorageUrl"];
                    var imageUrl = $"{storageURL}{companyDetail.LogoPath}";

                    string emailBody = $@"
                                          <html>
                                              <body>
                                                  <table align='center' style='width: 100%; text-align: center;'>
                                                      <tr>
                                                          <td>
                                                              <table align='center' border='1' cellpadding='10' cellspacing='0' style='width: 50%; margin-top: 20px;'>
                                                                  <tr>
                                                                      <th align='left'>Email</th>
                                                                      <td>{employee.Email}</td>
                                                                  </tr>
                                                                  <tr>
                                                                      <th align='left'>Kullanıcı Adı</th>
                                                                      <td>{employee.UserName}</td>
                                                                  </tr>
                                                                  <tr>
                                                                      <th align='left'>Şifre</th>
                                                                      <td>{newPassword}</td>
                                                                  </tr>
                                                              </table>
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </body>
                                          </html>";

                    List<Attachment> attachments = null;

                    try
                    {
                        using (var httpClient = new HttpClient())
                        {
                            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
                            attachments = new List<Attachment> { new Attachment { ContentBytes = imageBytes, Filename = "company_logo.png", ContentType = "image/png" } };

                            // Add logo image to email body
                            emailBody = $@"
                                        <html>
                                            <body>
                                                <table align='center' style='width: 100%; text-align: center;'>
                                                    <tr>
                                                        <td>
                                                              <img src='cid:company_logo' alt='logo' style='display: block; margin-left: auto; margin-right: auto;' height='80' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table align='center' border='1' cellpadding='10' cellspacing='0' style='width: 50%; margin-top: 20px;'>
                                                                <tr>
                                                                    <th align='left'>Email</th>
                                                                    <td>{employee.Email}</td>
                                                                </tr>
                                                                <tr>
                                                                    <th align='left'>Kullanıcı Adı</th>
                                                                    <td>{employee.UserName}</td>
                                                                </tr>
                                                                <tr>
                                                                    <th align='left'>Şifre</th>
                                                                    <td>{newPassword}</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </body>
                                        </html>";
                        }
                    }
                    catch (Exception ex)
                    {
                        createdResponse.Message += $"  --- Failed to retrieve image from URL: {ex.Message}";
                    }

                    var mailCredential = new MailVM
                    {
                        To = new[] { employee.Email },
                        Subject = "GControl Hesap Bilgileriniz",
                        Body = emailBody,
                        IsBodyHtml = true,
                        Attachments = attachments
                    };
                    await _mailService.SendEMmailAsync(mailCredential);
                }
            }

            return createdResponse;
        }
        private string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder password = new StringBuilder();
            Random random = new Random();
            while (0 < length--)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }
            return password.ToString();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
