using BaseProject.Application.Abstractions.Services.Identity;
using MediatR;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.UpdatePassword
{
    public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordRequest, UpdatePasswordResponse>
    {
        readonly IAppUserService _appUserService;

        public UpdatePasswordHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<UpdatePasswordResponse> Handle(UpdatePasswordRequest request, CancellationToken cancellationToken)
        {
            if (request.Password != request.PasswordConfirm)
                throw new Exception("Passwords do not match");

            await _appUserService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);

            return new()
            {
                Message = "Password change successful.",
            };
        }
    }
}