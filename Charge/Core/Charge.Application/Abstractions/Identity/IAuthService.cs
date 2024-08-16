using GCharge.Application.DTOs.Identity.Auth;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;

namespace GCharge.Application.Abstractions.Identity
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model);

        Task<LoginResponseDTO> RefreshTokenLoginAsync(string refreshToken);

        Task PasswordResetAsync(string email);

        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
    }
}