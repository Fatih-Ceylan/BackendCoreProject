using BaseProject.Application.Abstractions.Services.Identity;
using MediatR;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginHandler : IRequestHandler<RefreshTokenLoginRequest, RefreshTokenLoginResponse>
    {
        IAuthService _authService;

        public RefreshTokenLoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RefreshTokenLoginResponse> Handle(RefreshTokenLoginRequest request, CancellationToken cancellationToken)
        {
            LoginResponseDTO loginResponseDto = await _authService.RefreshTokenLoginAsync(request.RefreshToken, request.UrlPath, request.MasterCompanyIdFromPlatform);
            return new()
            {
                Token = loginResponseDto.Token,
                Message = loginResponseDto.Message
            };
        }
    }
}