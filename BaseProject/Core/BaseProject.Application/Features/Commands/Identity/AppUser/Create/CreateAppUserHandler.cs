using AutoMapper;
using BaseProject.Application.Abstractions.Services.Identity;
using BaseProject.Application.DTOs.Identity.AppUser;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Exceptions;
using T = BaseProject.Domain.Entities.Identity;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.Create
{
    public class CreateAppUserHandler : IRequestHandler<CreateAppUserRequest, CreateAppUserResponse>
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

        public async Task<CreateAppUserResponse> Handle(CreateAppUserRequest request, CancellationToken cancellationToken)
        {
            if (request.Password != request.PasswordConfirm)
                throw new PasswordConfirmException();

            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.FileOptions != null)
                uploadedDatas = await _storageService.UploadAsync("AppUser-Files", request.FileOptions);

            var appUserRequestDto = _mapper.Map<CreateUserRequestDTO>(request);
            appUserRequestDto.ProfileImagePath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : null;
            var appUserResponseDto = await _appUserService.CreateAsync(appUserRequestDto);

            var appUser = _mapper.Map<T.AppUser>(appUserResponseDto);

            var createdResponse = _mapper.Map<CreateAppUserResponse>(appUserResponseDto);
            createdResponse.MessageList = new();
            createdResponse.MessageList.Add(appUserResponseDto.Message);

            //if (uploadedDatas != null)
            //{
            //    await _appUserFileWriteRepository.AddRangeAsync(uploadedDatas.Select(r => new AppUserFile()
            //    {
            //        FileName = r.fileName,
            //        Path = r.pathOrContainerName,
            //        Storage = _storageService.StorageName,
            //        AppUsers = new List<T.AppUser>() { appUser }
            //    }).ToList());
            //}
            //await _appUserFileWriteRepository.SaveAsync();

            //List<AppUserLicense> appUserLicenses = new();
            //AppUserLicense appUserLicense;

            //foreach (var item in request.AppUserLicenses)
            //{
            //    appUserLicense = new();
            //    appUserLicense.AppUserId = appUser.Id;
            //    appUserLicense.LicenseId = Guid.Parse(item.LicenseId);
            //    appUserLicense.IsInUse = item.IsInUse;
            //    appUserLicenses.Add(appUserLicense);
            //}
            

            //await _appUserLicenseWriteRepository.AddRangeAsync(appUserLicenses);
            //await _appUserLicenseWriteRepository.SaveAsync();
            //createdResponse.MessageList.Add("The process of assigning licensed modules to the user was successful.");

            return createdResponse;
        }
    }
}