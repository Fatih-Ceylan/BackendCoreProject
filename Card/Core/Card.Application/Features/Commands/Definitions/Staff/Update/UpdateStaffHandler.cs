using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.Staff.Update
{
    public class UpdateStaffHandler : IRequestHandler<UpdateStaffRequest, UpdateStaffResponse>
    {
        readonly IStaffWriteRepository _staffWriteRepository;
        readonly IStaffReadRepository _staffReadRepository;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly IConfiguration _configuration;
        readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateStaffHandler(IStaffWriteRepository staffWriteRepository, IStaffReadRepository staffReadRepository, IMapper mapper, IStorageService storageService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor = null)
        {
            _staffWriteRepository = staffWriteRepository;
            _staffReadRepository = staffReadRepository;
            _mapper = mapper;
            _storageService = storageService;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<UpdateStaffResponse> Handle(UpdateStaffRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }
            if (request.BranchId == "SelectAll")
            {
                request.BranchId = null;
            }

            var staff = await _staffReadRepository.GetByIdAsync(request.Id);
            string[] fileName;

            var route = _httpContextAccessor?.HttpContext?.Request?.Headers?["Route-Name"];

            if (staff.ProfilePicturePath != null)
            {
                fileName = staff.ProfilePicturePath.Split('\\') != null ? staff.ProfilePicturePath.Split('\\') : new string[] { "" };

                if (request.ProfilePicturePath == null && request.Files == null)
                {
                    try
                    {
                        await _storageService.DeleteAsync(fileName[0], fileName[1]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    staff.ProfilePicturePath = null;
                }
            }

            var storageURL = _configuration["Storage:BaseFrontendUrl"];
            staff.StaffUrl = $"{storageURL}{route}/Card-userqr/{staff.Id.ToString()}";

            if (request.Files != null)
            {
                List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
                if (request.Files.Count > 0)
                {
                    uploadedDatas = await _storageService.UploadAsync("Staff-ProfilePictures", request.Files);
                    request.ProfilePicturePath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : null;
                }
            }

            staff = _mapper.Map(request, staff);
            await _staffWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateStaffResponse>(staff);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
