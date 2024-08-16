using MediatR;

namespace GCharge.Application.Features.Commands.Identity.AppUser.VerifyEmailToken
{
    public class VerifyEmailTokenRequest: IRequest<VerifyEmailTokenResponse>
    {
        public string EmailToken { get; set; }

    }
}