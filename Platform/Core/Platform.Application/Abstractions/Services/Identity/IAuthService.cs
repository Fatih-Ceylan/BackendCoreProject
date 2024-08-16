using Platform.Application.DTOs.Identity.Auth;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;

namespace Platform.Application.Abstractions.Services.Identity
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model);

        Task<LoginResponseDTO> RefreshTokenLoginAsync(string refreshToken);
    }
}