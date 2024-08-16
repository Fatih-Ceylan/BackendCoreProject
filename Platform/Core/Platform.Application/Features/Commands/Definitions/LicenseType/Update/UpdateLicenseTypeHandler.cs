using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.LicenseType.Update
{
    public class UpdateLicenseTypeHandler : IRequestHandler<UpdateLicenseTypeRequest, UpdateLicenseTypeResponse>
    {
        readonly ILicenseTypeReadRepository _licenseTypeReadRepository;
        readonly ILicenseTypeWriteRepository _licenseTypeWriteRepository;
        readonly IMapper _mapper;

        public UpdateLicenseTypeHandler(ILicenseTypeReadRepository licenseTypeReadRepository, ILicenseTypeWriteRepository licenseTypeWriteRepository, IMapper mapper)
        {
            _licenseTypeReadRepository = licenseTypeReadRepository;
            _licenseTypeWriteRepository = licenseTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateLicenseTypeResponse> Handle(UpdateLicenseTypeRequest request, CancellationToken cancellationToken)
        {
            var licenseType = await _licenseTypeReadRepository.GetByIdAsync(request.Id);
            licenseType = _mapper.Map(request, licenseType);
            await _licenseTypeWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateLicenseTypeResponse>(licenseType);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}