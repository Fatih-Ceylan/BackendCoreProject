using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Identity.Staff.ForgotPassword
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordRequest, ForgotPasswordResponse>
    {
        readonly IStaffReadRepository _staffReadRepository;
        readonly IStaffWriteRepository _staffWriteRepository;
        readonly IPasswordRemakeReadRepository _passwordRemakeReadRepository;
        readonly IPasswordRemakeWriteRepository _passwordRemakeWriteRepository;
        readonly IMapper _mapper;

        public ForgotPasswordHandler(IStaffReadRepository staffReadRepository, IPasswordRemakeReadRepository passwordRemakeReadRepository, IMapper mapper, IStaffWriteRepository staffWriteRepository, IPasswordRemakeWriteRepository passwordRemakeWriteRepository)
        {
            _staffReadRepository = staffReadRepository;
            _passwordRemakeReadRepository = passwordRemakeReadRepository;
            _mapper = mapper;
            _staffWriteRepository = staffWriteRepository;
            _passwordRemakeWriteRepository = passwordRemakeWriteRepository;
        }

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var staff = _staffReadRepository.GetByIdAsync(request.StaffId).Result;

            T.PasswordRemake passwordRemake = new T.PasswordRemake();

            if (staff != null)
            {
                passwordRemake = _passwordRemakeReadRepository.GetByEmailAsync(staff.Email).Result;

                if (passwordRemake != null)
                {
                    string hashedPassword = "";

                    if (request.Password == request.PasswordConfirm)
                    {
                        if (passwordRemake.Token == request.VerificationCode)
                        {
                            if (passwordRemake.CreatedDate.AddMinutes(3) >= DateTime.Now)
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

                                staff = _mapper.Map(request, staff);
                                staff.Password = hashedPassword;

                                await _staffWriteRepository.SaveAsync();

                                _passwordRemakeWriteRepository.HardDeleteById(passwordRemake.Id.ToString());
                                await _passwordRemakeWriteRepository.SaveAsync();

                                return new()
                                {
                                    Message = CommandResponseMessage.Success.ToString(),
                                    StatusCode = "200"
                                };
                            }
                            else
                            {
                                return new()
                                {
                                    Message = CommandResponseMessage.SessionExpired.ToString(),
                                    StatusCode = "419"
                                };
                            }

                        }
                        else
                        {
                            return new()
                            {
                                Message = CommandResponseMessage.VerificationCodeUnmatched.ToString(),
                                StatusCode = "403"
                            };
                        }
                    }
                    else
                    {
                        return new()
                        {
                            Message = CommandResponseMessage.PasswordNotMatched.ToString(),
                            StatusCode = "400"
                        };
                    }

                }
                else
                {
                    return new()
                    {
                        Message = CommandResponseMessage.TokenNotValid.ToString(),
                        StatusCode = "401"
                    };
                }
            }

            else
            {
                return new()
                {
                    Message = CommandResponseMessage.UserNotFound.ToString(),
                    StatusCode = "404"
                };
            }

        }
    }
}
