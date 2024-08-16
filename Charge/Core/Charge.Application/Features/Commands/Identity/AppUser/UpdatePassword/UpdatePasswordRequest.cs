using MediatR;

namespace GCharge.Application.Features.Commands.Identity.AppUser.UpdatePassword
{
    public class UpdatePasswordRequest: IRequest<UpdatePasswordResponse>
    {
        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public string UserId { get; set; }

        public string ResetToken { get; set; }
    }
}
