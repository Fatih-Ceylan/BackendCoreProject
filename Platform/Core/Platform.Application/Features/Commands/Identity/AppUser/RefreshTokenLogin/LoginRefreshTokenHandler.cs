using MediatR;
using Platform.Application.Abstractions.Services.Identity;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;

namespace Platform.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin
{
    public class LoginRefreshTokenHandler : IRequestHandler<LoginRefreshTokenRequest, LoginRefreshTokenResponse>
    {
        readonly IAuthService _authService;

        public LoginRefreshTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginRefreshTokenResponse> Handle(LoginRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            LoginResponseDTO loginResponseDto = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
            return new()
            {
                Token = loginResponseDto.Token,
                Message = loginResponseDto.Message,
            };
        }
    }
}
