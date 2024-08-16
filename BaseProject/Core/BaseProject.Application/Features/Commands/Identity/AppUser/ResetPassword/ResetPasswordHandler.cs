using BaseProject.Application.Abstractions.Services.Identity;
using MediatR;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.ResetPassword
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse>
    {
        readonly IAuthService _authService;

        public ResetPasswordHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            await _authService.PasswordResetAsync(request.Email);

            return new()
            {
                Message = $"An e-mail was sent to {request.Email} address for password change."
            };
        }
    }
}