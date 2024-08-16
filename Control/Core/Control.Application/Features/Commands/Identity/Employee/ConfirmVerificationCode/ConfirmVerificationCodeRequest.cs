using MediatR;

namespace GControl.Application.Features.Commands.Identity.Employee.ConfirmVerificationCode
{
    public class ConfirmVerificationCodeRequest : IRequest<ConfirmVerificationCodeResponse>
    {
        public string VerificationCode { get; set; }
    }
}
