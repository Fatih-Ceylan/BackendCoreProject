using MediatR;
using Platform.Application.Abstractions.Services.Identity;

namespace Platform.Application.Features.Queries.Identity.AppUser.GetById
{
    public class GetByIdAppUserHandler : IRequestHandler<GetByIdAppUserRequest, GetByIdAppUserResponse>
    {
        readonly IAppUserService _appUserService;

        public GetByIdAppUserHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<GetByIdAppUserResponse> Handle(GetByIdAppUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _appUserService.GetByIdAsync(request.Id);

            return new()
            {
                User = user.User
            };
        }
    }
}
