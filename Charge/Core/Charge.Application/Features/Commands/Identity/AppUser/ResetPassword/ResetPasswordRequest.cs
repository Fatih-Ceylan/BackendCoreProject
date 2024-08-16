using MediatR;

namespace GCharge.Application.Features.Commands.Identity.AppUser.ResetPassword
{
    public class ResetPasswordRequest: IRequest<ResetPasswordResponse>
    {
        public string Email { get; set; }
    }
}