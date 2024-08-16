using Utilities.Core.UtilityApplication.DTOs.Identity;

namespace GCharge.Application.Features.Commands.Identity.AppUser.Login
{
    public class LoginAppUserResponse
    {
        public TokenDTO Token { get; set; }

        public string Message { get; set; }
    }
}