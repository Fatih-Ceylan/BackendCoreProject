using Utilities.Core.UtilityApplication.DTOs.Identity;

namespace Platform.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin
{
    public class LoginRefreshTokenResponse
    {
        public TokenDTO Token { get; set; }

        public string Message { get; set; }
    }
}