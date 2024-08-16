using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Identity.Employee.ChangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, ChangePasswordResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IMapper _mapper;

        public ChangePasswordHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository, IMapper mapper)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _mapper = mapper;
        }

        public async Task<ChangePasswordResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.EmployeeId);

            if (employee != null)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // Mevcut şifreyi doğrula
                    byte[] currentPasswordBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(request.CurrentPassword));
                    StringBuilder currentPasswordBuilder = new StringBuilder();
                    for (int i = 0; i < currentPasswordBytes.Length; i++)
                    {
                        currentPasswordBuilder.Append(currentPasswordBytes[i].ToString("x2"));
                    }
                    string currentHashedPassword = currentPasswordBuilder.ToString();

                    // Mevcut şifre doğruysa devam et
                    if (currentHashedPassword == employee.Password)
                    {
                        // Yeni şifre ve tekrar yazılan şifre aynı mı kontrol et
                        if (request.Password == request.PasswordConfirm)
                        {
                            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                            StringBuilder builder = new StringBuilder();
                            for (int i = 0; i < bytes.Length; i++)
                            {
                                builder.Append(bytes[i].ToString("x2"));
                            }
                            string hashedPassword = builder.ToString();

                            // Şifreyi güncelle
                            employee = _mapper.Map(request, employee);
                            employee.Password = hashedPassword;

                            await _employeeWriteRepository.SaveAsync();

                            return new()
                            {
                                Message = CommandResponseMessage.UpdatedSuccess.ToString(),
                            };
                        }
                        else
                        {
                            return new()
                            {
                                Message = "PasswordsDoNotMatch"
                            };
                        }
                    }
                    else
                    {
                        return new()
                        {
                            Message = "IncorrectCurrentPassword"
                        };
                    }
                }
            }
            else
            {
                return new()
                {
                    Message = CommandResponseMessage.UserNotFound.ToString(),
                };
            }
        }
   }
}