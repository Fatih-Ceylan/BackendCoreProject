using AutoMapper;
using BaseProject.Application.Abstractions.Services.Identity;
using BaseProject.Application.DTOs.Identity.AppUser;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using BaseProject.Domain.Entities.Definitions;
using MediatR;
using System.Linq.Expressions;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using T = BaseProject.Domain.Entities.Identity;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.Update
{
    public class UpdateAppUserHandler : IRequestHandler<UpdateAppUserRequest, UpdateAppUserResponse>
    {
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly IAppUserLicenseWriteRepository _appUserLicenseWriteRepository;
        readonly IAppUserLicenseReadRepository _appUserLicenseReadRepository;

        public UpdateAppUserHandler(IAppUserService appUserService, IMapper mapper, IStorageService storageService, IAppUserLicenseWriteRepository appUserLicenseWriteRepository, IAppUserLicenseReadRepository appUserLicenseReadRepository)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _storageService = storageService;
            _appUserLicenseWriteRepository = appUserLicenseWriteRepository;
            _appUserLicenseReadRepository = appUserLicenseReadRepository;
        }

        public async Task<UpdateAppUserResponse> Handle(UpdateAppUserRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.FileOptions != null)
                uploadedDatas = await _storageService.UploadAsync("AppUser-Files", request.FileOptions);

            var updateRequestDto = _mapper.Map<UpdateUserRequestDTO>(request);
            updateRequestDto.ProfileImagePath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : null;
            var updateResponseDto = await _appUserService.UpdateAsync(updateRequestDto);
            var appUser = _mapper.Map<T.AppUser>(updateResponseDto);

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

            var updatedResponse = _mapper.Map<UpdateAppUserResponse>(updateResponseDto);
            updatedResponse.MessageList = new();
            updatedResponse.MessageList.Add(updateResponseDto.Message);

            Expression<Func<AppUserLicense, bool>> licenseFilter = cl => request.AppUserLicenses.Select(x => x.LicenseId).ToList().Contains(cl.LicenseId.ToString());
            var appUserLicensesQuery = _appUserLicenseReadRepository.GetAllDeletedStatus(false, false)
                                                                    .Where(cl => cl.AppUserId == request.Id);
            appUserLicensesQuery = appUserLicensesQuery.Where(licenseFilter);
            List<AppUserLicense>? appUserLicenses = appUserLicensesQuery.ToList();
            List<AppUserLicense> createAppUserLicenses = new();
            AppUserLicense createAppUserLicense;

            if (appUserLicenses != null)
            {
                _appUserLicenseWriteRepository.HardDeleteRange(appUserLicenses);
            }

            foreach (var requestAppUserLicense in request.AppUserLicenses)
            {
                createAppUserLicense = new();
                createAppUserLicense.AppUserId = request.Id;
                createAppUserLicense.LicenseId = Guid.Parse(requestAppUserLicense.LicenseId);
                createAppUserLicense.IsInUse = requestAppUserLicense.IsInUse;
                createAppUserLicenses.Add(createAppUserLicense);
            }

            await _appUserLicenseWriteRepository.AddRangeAsync(createAppUserLicenses);
            await _appUserLicenseWriteRepository.SaveAsync();
            updatedResponse.MessageList.Add("The process of assigning licensed modules to the company was successful.");

            return updatedResponse;
        }
    }
}