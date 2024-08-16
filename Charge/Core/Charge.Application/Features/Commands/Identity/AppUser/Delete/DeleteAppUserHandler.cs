using GCharge.Application.Abstractions.Identity;
using MediatR;

namespace GCharge.Application.Features.Commands.Identity.AppUser.Delete
{
    public class DeleteAppUserHandler : IRequestHandler<DeleteAppUserRequest, DeleteAppUserResponse>
    {
        readonly IAppUserService _appUserService;

        public DeleteAppUserHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<DeleteAppUserResponse> Handle(DeleteAppUserRequest request, CancellationToken cancellationToken)
        {
            var deletedResponse = await _appUserService.SoftDelete(request.Id);

            return new()
            {
                Succeed = deletedResponse.Succeed,
                Message = deletedResponse.Message,
            };
        }
    }
}