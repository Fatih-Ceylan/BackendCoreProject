using AutoMapper;
using BaseProject.Application.Abstractions.Services.Identity;
using BaseProject.Application.DTOs.Identity.AppUser;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Exceptions;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.CreateFromPlatform
{
    public class CreateAppUserHandler : IRequestHandler<CreateAppUserFromPlatformRequest, CreateAppUserFromPlatformResponse>
    {
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly IAppUserLicenseWriteRepository _appUserLicenseWriteRepository;

        public CreateAppUserHandler(IAppUserService appUserService, IMapper mapper, IStorageService storageService, IAppUserLicenseWriteRepository appUserLicenseWriteRepository)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _storageService = storageService;
            _appUserLicenseWriteRepository = appUserLicenseWriteRepository;
        }

        public async Task<CreateAppUserFromPlatformResponse> Handle(CreateAppUserFromPlatformRequest request, CancellationToken cancellationToken)
        {
            if (request.Password != request.PasswordConfirm)
                throw new PasswordConfirmException();

            if (request.ProfileImagePath != "850762ab-3786-47ee-8219-cc3178b931d7")
                throw new Exception("This request is only available when creating a company from platform administration.");

            var appUserRequestDto = _mapper.Map<CreateUserRequestDTO>(request);
            appUserRequestDto.ProfileImagePath = null;
            var appUserResponseDto = await _appUserService.CreateAsync(appUserRequestDto);

            return _mapper.Map<CreateAppUserFromPlatformResponse>(appUserResponseDto);
        }
    }
}