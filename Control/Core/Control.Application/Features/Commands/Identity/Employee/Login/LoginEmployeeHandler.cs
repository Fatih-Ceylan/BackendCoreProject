using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Identity.Employee.Login
{
    public class LoginEmployeeHandler : IRequestHandler<LoginEmployeeRequest, LoginEmployeeResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IBranchReadRepository _branchReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IMapper _mapper;

        public LoginEmployeeHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository, IMapper mapper, ICompanyReadRepository companyReadRepository, IBranchReadRepository branchReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _mapper = mapper; 
            _companyReadRepository = companyReadRepository;
            _branchReadRepository = branchReadRepository;
        }

        public async Task<LoginEmployeeResponse> Handle(LoginEmployeeRequest request, CancellationToken cancellationToken)
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

            var user = _employeeReadRepository.Table.FirstOrDefault(u => u.UserName == request.UserName && u.Password == hashedPassword);

            var expirationDate = DateTime.Now.AddDays(30).ToString("dd.MM.yyyy HH:mm:ss");

            if (user != null)
            {
                var token = GenerateRandomAlphanumeric(expirationDate);

                user.Token = token;
                user = _mapper.Map(request, user);
                user.Password = hashedPassword;

                await _employeeWriteRepository.SaveAsync();

                var branches = _branchReadRepository.GetAll();
                var matchedBranch = branches.FirstOrDefault(branch => branch.Id == user.BranchId);

                var companies = _companyReadRepository.GetAll();
                var matchedCompany = companies.FirstOrDefault(company => company.Id == user.CompanyId);

                var userResponse = new UserResponse()
                {
                    EmployeeId = user.Id.ToString(),
                    EmployeeName = user.FullName,
                    CompanyId = user.CompanyId.ToString(),
                    CompanyName = matchedCompany.Name,
                    BranchId = user.BranchId.ToString(),
                    BranchName = matchedBranch.Name,
                    Token = token,
                    LocationId = user.LocationId.ToString(),
                };

                var commandResponse = new CommandResponse()
                {
                    Message = CommandResponseMessage.LoginSuccess.ToString(),
                    StatusCode = null // İsteğe bağlı, durum kodunu burada belirleyebilirsiniz
                };

                return new LoginEmployeeResponse()
                {
                    UserResponse = userResponse,
                    CommandResponse = commandResponse
                };
            }
            else
            {
                var commandResponse = new CommandResponse()
                {
                    Message = CommandResponseMessage.UserNotFound.ToString(),
                    StatusCode = null // İsteğe bağlı, durum kodunu burada belirleyebilirsiniz
                };

                return new LoginEmployeeResponse()
                {
                    UserResponse = null,
                    CommandResponse = commandResponse
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
