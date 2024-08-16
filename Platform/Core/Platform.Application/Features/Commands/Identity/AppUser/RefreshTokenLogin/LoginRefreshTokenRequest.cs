using MediatR;

namespace Platform.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin
{
    public class LoginRefreshTokenRequest : IRequest<LoginRefreshTokenResponse>
    {
        public string RefreshToken { get; set; }
    }
}
