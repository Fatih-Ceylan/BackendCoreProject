using AutoMapper;
using MediatR;
using Platform.Application.Abstractions.Services.Identity;
using Platform.Application.DTOs.Identity.AppUser;
using Utilities.Core.UtilityApplication.Exceptions;

namespace Platform.Application.Features.Commands.Identity.AppUser.Create
{
    public class CreateAppUserHandler : IRequestHandler<CreateAppUserRequest, CreateAppUserResponse>
    {
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;

        public CreateAppUserHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public async Task<CreateAppUserResponse> Handle(CreateAppUserRequest request, CancellationToken cancellationToken)
        {
            if (request.Password != request.PasswordConfirm)
                throw new PasswordConfirmException();

            var appUserRequestDto = _mapper.Map<CreateUserRequestDTO>(request);
            var appUserResponseDto = await _appUserService.CreateAsync(appUserRequestDto);

            return _mapper.Map<CreateAppUserResponse>(appUserResponseDto);
        }
    }
}