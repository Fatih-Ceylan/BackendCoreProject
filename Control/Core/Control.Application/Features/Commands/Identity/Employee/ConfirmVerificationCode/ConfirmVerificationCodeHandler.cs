using GControl.Application.Repositories.ReadRepository;
using MediatR;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Identity.Employee.ConfirmVerificationCode
{
    public class ConfirmVerificationCodeHandler : IRequestHandler<ConfirmVerificationCodeRequest, ConfirmVerificationCodeResponse>
    {
        readonly IPasswordRemakeReadRepository _passwordRemakeReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;

        public ConfirmVerificationCodeHandler(IPasswordRemakeReadRepository passwordRemakeReadRepository, IEmployeeReadRepository employeeReadRepository)
        {
            _passwordRemakeReadRepository = passwordRemakeReadRepository;
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<ConfirmVerificationCodeResponse> Handle(ConfirmVerificationCodeRequest request, CancellationToken cancellationToken)
        {
            var passwordRemake = _passwordRemakeReadRepository.GetByTokenAsync(request.VerificationCode).Result;

            T.Employee staff = new T.Employee();

            if (passwordRemake == null)
            {
                return new()
                {
                    //Message = CommandResponseMessage.NotFound.ToString(),
                    StatusCode = "404"
                };
            }
            else if (passwordRemake.Token != request.VerificationCode)
            {
                return new()
                {
                    //Message = CommandResponseMessage.VerificationCodeUnmatched.ToString(),
                    StatusCode = "403"
                };
            }
            else
            {
                staff = _employeeReadRepository.GetByEmailAsync(passwordRemake.Email).Result;

                return new()
                {
                    //Message = CommandResponseMessage.Success.ToString(),
                    StatusCode = "200",
                    EmployeeId = staff.Id.ToString(),
                    VerificationCode = passwordRemake.Token
                };
            }
        }
    }
}
