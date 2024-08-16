using Utilities.Core.UtilityApplication.DTOs.Identity;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginResponse
    {
        public TokenDTO Token { get; set; }

        public string Message { get; set; }
    }
}