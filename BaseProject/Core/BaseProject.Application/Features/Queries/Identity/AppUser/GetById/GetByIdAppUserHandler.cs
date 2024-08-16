using AutoMapper;
using BaseProject.Application.Abstractions.Services.Identity;
using BaseProject.Application.VMs.Definitions.AppUser;
using MediatR;

namespace BaseProject.Application.Features.Queries.Identity.AppUser.GetById
{
    public class GetByIdAppUserHandler : IRequestHandler<GetByIdAppUserRequest, GetByIdAppUserResponse>
    {
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;

        public GetByIdAppUserHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public async Task<GetByIdAppUserResponse> Handle(GetByIdAppUserRequest request, CancellationToken cancellationToken)
        {
            var appUserDto = await _appUserService.GetByIdAsync(request.Id);
            var appUserVM = _mapper.Map<AppUserVM>(appUserDto);

            return new()
            {
                AppUser = appUserVM
            };
        }
    }
}