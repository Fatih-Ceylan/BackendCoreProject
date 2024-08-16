using MediatR;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.VerifyResetToken
{
    public class VerifyResetTokenRequest: IRequest<VerifyResetTokenResponse>
    {
        public string ResetToken { get; set; }

        public string UserId { get; set; }
    }
}