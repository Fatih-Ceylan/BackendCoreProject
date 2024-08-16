using AutoMapper;
using GCharge.Application.Abstractions.Identity;
using GCharge.Application.DTOs.Identity.AppUser;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;

namespace GCharge.Application.Features.Commands.Identity.AppUser.Update
{
    public class UpdateAppUserHandler : IRequestHandler<UpdateAppUserRequest, UpdateAppUserResponse>
    {
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;

        public UpdateAppUserHandler(IAppUserService appUserService, IMapper mapper, IStorageService storageService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<UpdateAppUserResponse> Handle(UpdateAppUserRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.FileOptions != null)
                uploadedDatas = await _storageService.UploadAsync("AppUser-Files", request.FileOptions);

            var updateRequestDto = _mapper.Map<UpdateUserRequestDTO>(request);
            updateRequestDto.ProfileImagePath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : null;
            var updateResponseDto = await _appUserService.UpdateAsync(updateRequestDto);
          
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
            updatedResponse.Message = updateResponseDto.Message;

            return updatedResponse;
        }
    }
}