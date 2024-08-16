using MediatR;
using Platform.Application.Abstractions.Services.Identity;

namespace Platform.Application.Features.Queries.Identity.AppUser.GetAll
{
    public class GetAllAppUserHandler : IRequestHandler<GetAllAppUserRequest, GetAllAppUserResponse>
    {
        readonly IAppUserService _appUserService;

        public GetAllAppUserHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public Task<GetAllAppUserResponse> Handle(GetAllAppUserRequest request, CancellationToken cancellationToken)
        {
            var users = _appUserService.GetAllDeletedStatus(request);

            return Task.FromResult(new GetAllAppUserResponse
            {
                TotalCount = users.TotalCount,
                Users = users.Users
            });
        }
    }
}