using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Identity.Staff.Login
{
    public class LoginStaffHandler : IRequestHandler<LoginStaffRequest, LoginStaffResponse>
    {
        readonly IStaffReadRepository _staffReadRepository; 
        readonly IStaffWriteRepository _staffWriteRepository;
        readonly IMapper _mapper;

        public LoginStaffHandler(IStaffReadRepository staffReadRepository, IStaffWriteRepository staffWriteRepository, IMapper mapper)
        {
            _staffReadRepository = staffReadRepository;
            _staffWriteRepository = staffWriteRepository;
            _mapper = mapper;
        }

        public async Task<LoginStaffResponse> Handle(LoginStaffRequest request, CancellationToken cancellationToken)
        {
            string hashedPassword = "";

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


            var user = _staffReadRepository.Table.FirstOrDefault(u => u.UserName == request.UserName && u.Password == hashedPassword);

            var expirationDate = DateTime.Now.AddMinutes(3).ToString("dd.MM.yyyy HH:mm:ss");

            if (user != null)
            { 
                var token = GenerateRandomAlphanumeric(expirationDate);
                user.Token = token;
                user = _mapper.Map(request, user);

                user.Password = hashedPassword;

                await _staffWriteRepository.SaveAsync();
                 
                  
                return new()
                {
                    Token = token,
                    Message=CommandResponseMessage.Success.ToString(),
                    StaffId=user.Id.ToString(),
                    StatusCode="200"
                };
            }

            else
            {
                return new()
                {
                    Token = string.Empty,
                    Message = CommandResponseMessage.UserNotFound.ToString(),
                    StatusCode="404"
                };
            }
        }

        private string GenerateRandomAlphanumeric(string time)
        {
            const string chars = "0123456789";
            Random random = new Random();
            StringBuilder builder = new StringBuilder(6);
            for (int i = 0; i < 6; i++)
            {
                builder.Append(chars[random.Next(chars.Length)]);
            }
            return $"{builder.ToString()}@{time}";
        } 
    }
}
