using AutoMapper;
using GControl.Application.Abstractions.Mail;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Identity.Employee.ForgotPassword
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordRequest, ForgotPasswordResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IMailService _mailService;
        readonly IPasswordRemakeReadRepository _passwordRemakeReadRepository;
        readonly IPasswordRemakeWriteRepository _passwordRemakeWriteRepository;
        readonly IMapper _mapper;

        public ForgotPasswordHandler(IEmployeeReadRepository employeeReadRepository, IMailService mailService, IPasswordRemakeReadRepository passwordRemakeReadRepository, IMapper mapper, IEmployeeWriteRepository employeeWriteRepository, IPasswordRemakeWriteRepository passwordRemakeWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _mailService = mailService;
            _passwordRemakeReadRepository = passwordRemakeReadRepository;
            _mapper = mapper;
            _employeeWriteRepository = employeeWriteRepository;
            _passwordRemakeWriteRepository = passwordRemakeWriteRepository;
        }

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var passwordRemake = _passwordRemakeReadRepository.GetByTokenAsync(request.Token).Result;

            T.Employee employee = new T.Employee();

            if (passwordRemake != null)
            {
                employee = _employeeReadRepository.GetByEmailAsync(passwordRemake.Email).Result;

                string hashedPassword = "";

                if (employee != null)
                {
                    if (request.Password == request.PasswordConfirm)
                    {
                        if (passwordRemake.Token == request.Token)
                        {
                            if (passwordRemake.CreatedDate.AddMinutes(30) >= DateTime.Now)
                            {
                                using (SHA256 sha256Hash = SHA256.Create())
                                {
                                    // Şifreyi byte dizisine dönüştür
                                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

                                    // Byte dizisini stringe dönüştür
                                    StringBuilder builder = new StringBuilder();
                                    for (int i = 0; i < bytes.Length; i++)
                                    {
                                        builder.Append(bytes[i].ToString("x2")); // hexadecimal formatında stringe dönüştür
                                    }
                                    hashedPassword = builder.ToString();
                                }

                                employee = _mapper.Map(request, employee);
                                employee.Password = hashedPassword;

                                await _employeeWriteRepository.SaveAsync();

                                _passwordRemakeWriteRepository.HardDeleteById(passwordRemake.Id.ToString());

                                return new()
                                {
                                    Message = CommandResponseMessage.UpdatedSuccess.ToString(),
                                };
                            }
                            else
                            {
                                return new()
                                {
                                    Message = CommandResponseMessage.SessionExpired.ToString(),
                                };
                            }

                        }
                        else
                        {
                            return new()
                            {
                                Message = CommandResponseMessage.TokenNotMatchedError.ToString(),
                            };
                        }
                    }
                    else
                    {
                        return new()
                        {
                            Message = CommandResponseMessage.UpdatedError.ToString(),
                        };
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
            else
            {
                return new()
                {
                    Message = CommandResponseMessage.AddedError.ToString(),
                };
            }

        }
    }
}
