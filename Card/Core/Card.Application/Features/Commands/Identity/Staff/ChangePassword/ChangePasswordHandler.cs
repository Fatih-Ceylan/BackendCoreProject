using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Identity.Staff.ChangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, ChangePasswordResponse>
    {
        readonly IStaffReadRepository _staffReadRepository;
        readonly IStaffWriteRepository _staffWriteRepository;
        readonly IMapper _mapper;

        public ChangePasswordHandler(IStaffReadRepository staffReadRepository, IStaffWriteRepository staffWriteRepository, IMapper mapper)
        {
            _staffReadRepository = staffReadRepository;
            _staffWriteRepository = staffWriteRepository;
            _mapper = mapper;
        }

        public async Task<ChangePasswordResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var staff = _staffReadRepository.GetByIdAsync(request.StaffId).Result;

            string hashedPassword = "";

            if (staff != null)
            {
                if (request.Password == request.PasswordConfirm)
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
                        Message = CommandResponseMessage.PasswordNotMatched.ToString(),
                        StatusCode = "400"
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
