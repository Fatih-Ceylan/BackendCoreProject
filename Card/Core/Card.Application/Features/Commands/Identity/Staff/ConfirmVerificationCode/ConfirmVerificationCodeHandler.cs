using Card.Application.Repositories.ReadRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Identity.Staff.ConfirmVerificationCode
{
    public class ConfirmVerificationCodeHandler : IRequestHandler<ConfirmVerificationCodeRequest, ConfirmVerificationCodeResponse>
    {
        readonly IPasswordRemakeReadRepository _passwordRemakeReadRepository;
        readonly IStaffReadRepository _staffReadRepository;

        public ConfirmVerificationCodeHandler(IPasswordRemakeReadRepository passwordRemakeReadRepository, IStaffReadRepository staffReadRepository)
        {
            _passwordRemakeReadRepository = passwordRemakeReadRepository;
            _staffReadRepository = staffReadRepository;
        }

        public async Task<ConfirmVerificationCodeResponse> Handle(ConfirmVerificationCodeRequest request, CancellationToken cancellationToken)
        {
            var passwordRemake = await _passwordRemakeReadRepository.GetByTokenAsync(request.VerificationCode);

            T.Staff staff = new T.Staff();

            if (passwordRemake == null)
            {
                return new()
                {
                    Message = CommandResponseMessage.NotFound.ToString(),
                    StatusCode = "404"
                };
            }
            else if (passwordRemake.Token != request.VerificationCode)
            {
                return new()
                {
                    Message = CommandResponseMessage.VerificationCodeUnmatched.ToString(),
                    StatusCode = "403"
                };
            }
            else
            {
                staff = await _staffReadRepository.GetByEmailAsync(passwordRemake.Email);

                return new()
                {
                    Message = CommandResponseMessage.Success.ToString(),
                    StatusCode = "200",
                    StaffId = staff.Id.ToString(),
                    VerificationCode = passwordRemake.Token
                };
            }
        }
    }
}
