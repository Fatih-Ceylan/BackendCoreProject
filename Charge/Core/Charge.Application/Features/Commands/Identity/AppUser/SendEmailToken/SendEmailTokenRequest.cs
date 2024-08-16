using MediatR;

namespace GCharge.Application.Features.Commands.Identity.AppUser.SendEmailToken
{
    public class SendEmailTokenRequest: IRequest<SendEmailTokenResponse>
    {
        public string Email { get; set; }

    }
}