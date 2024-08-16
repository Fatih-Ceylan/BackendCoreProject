using MediatR;

namespace GControl.Application.Features.Commands.Identity.Employee.ForgotPassword
{
    public class ForgotPasswordRequest : IRequest<ForgotPasswordResponse>
    {
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Token { get; set; }
    }
}
