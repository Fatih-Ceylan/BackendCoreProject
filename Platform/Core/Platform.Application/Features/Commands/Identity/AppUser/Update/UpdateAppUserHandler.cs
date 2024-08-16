using AutoMapper;
using MediatR;
using Platform.Application.Abstractions.Services.Identity;
using Platform.Application.DTOs.Identity.AppUser;

namespace Platform.Application.Features.Commands.Identity.AppUser.Update
{
    public class UpdateAppUserHandler : IRequestHandler<UpdateAppUserRequest, UpdateAppUserResponse>
    {
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;

        public UpdateAppUserHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public async Task<UpdateAppUserResponse> Handle(UpdateAppUserRequest request, CancellationToken cancellationToken)
        {
            var updatedResponse = await _appUserService.UpdateAsync(_mapper.Map<UpdateUserRequestDTO>(request));

            return _mapper.Map<UpdateAppUserResponse>(updatedResponse);
        }
    }
}