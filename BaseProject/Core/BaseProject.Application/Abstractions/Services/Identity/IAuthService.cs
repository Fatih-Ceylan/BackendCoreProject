using BaseProject.Application.DTOs.Identity.Auth;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;

namespace BaseProject.Application.Abstractions.Services.Identity
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model);

        Task<LoginResponseDTO> RefreshTokenLoginAsync(string refreshToken, string urlPath, string masterCompanyIdFromPlatform);

        Task PasswordResetAsync(string email);

        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
    }
}