using MediatR;

namespace Card.Application.Features.Commands.Identity.Staff.ConfirmVerificationCode
{
    public class ConfirmVerificationCodeRequest : IRequest<ConfirmVerificationCodeResponse>
    {
        public string VerificationCode { get; set; }
    }
}
