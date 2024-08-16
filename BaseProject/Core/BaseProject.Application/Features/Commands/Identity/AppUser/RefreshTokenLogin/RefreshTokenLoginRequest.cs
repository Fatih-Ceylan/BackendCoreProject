using MediatR;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginRequest : IRequest<RefreshTokenLoginResponse>
    {
        public string RefreshToken { get; set; }

        public string UrlPath { get; set; }

        public string MasterCompanyIdFromPlatform { get; set; }
    }
}
