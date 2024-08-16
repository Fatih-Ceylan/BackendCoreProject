using MediatR;

namespace Card.Application.Features.Commands.Identity.Staff.ForgotPassword
{
    public class ForgotPasswordRequest : IRequest<ForgotPasswordResponse>
    {
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string VerificationCode { get; set; }
        public string StaffId { get; set; }
    }
}
