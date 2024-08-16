using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Identity.Employee.Login
{
    public class LoginEmployeeHandler : IRequestHandler<LoginEmployeeRequest, LoginEmployeeResponse>
    {
        readonly IEmployeeReadRepository _EmployeeReadRepository;
        readonly IEmployeeWriteRepository _EmployeeWriteRepository;

        public LoginEmployeeHandler(IEmployeeReadRepository EmployeeReadRepository, IEmployeeWriteRepository EmployeeWriteRepository)
        {
            _EmployeeReadRepository = EmployeeReadRepository;
            _EmployeeWriteRepository = EmployeeWriteRepository;
        }

        public Task<LoginEmployeeResponse> Handle(LoginEmployeeRequest request, CancellationToken cancellationToken)
        {
            var user = _EmployeeReadRepository.Table.FirstOrDefault(u => u.UserName == request.UserName && u.Password == request.Password);

            var expirationDate = DateTime.Now.AddSeconds(100).ToString("dd.MM.yyyy HH:mm:ss");

            if (user != null)
            {
                var token = GenerateRandomAlphanumeric(expirationDate);

                user.UserName = request.UserName;
                user.Password = request.Password;
                user.Token = token;

                _EmployeeWriteRepository.SaveAsync();


                return Task.FromResult(new LoginEmployeeResponse
                {
                    Token = token,
                    Message = CommandResponseMessage.UpdatedSuccess.ToString()
                });
            }

            else
            {
                return Task.FromResult(new LoginEmployeeResponse
                {
                    Token = string.Empty,
                    Message = CommandResponseMessage.UpdatedError.ToString()
                });
            }
        }

        private string GenerateRandomAlphanumeric(string time)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            StringBuilder builder = new StringBuilder(64);
            for (int i = 0; i < 64; i++)
            {
                builder.Append(chars[random.Next(chars.Length)]);
            }
            return $"{builder.ToString()}@{time}";
        }
    }
}
