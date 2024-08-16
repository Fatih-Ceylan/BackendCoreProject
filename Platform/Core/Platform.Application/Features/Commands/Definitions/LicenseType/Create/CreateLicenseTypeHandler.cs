using AutoMapper;
using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.LicenseType.Create
{
    public class CreateLicenseTypeHandler : IRequestHandler<CreateLicenseTypeRequest, CreateLicenseTypeResponse>
    {
        readonly ILicenseTypeWriteRepository _licenseTypeWriteRepository;
        readonly IMapper _mapper;

        public CreateLicenseTypeHandler(ILicenseTypeWriteRepository licenseTypeWriteRepository, IMapper mapper)
        {
            _licenseTypeWriteRepository = licenseTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateLicenseTypeResponse> Handle(CreateLicenseTypeRequest request, CancellationToken cancellationToken)
        {
            var licenseType = _mapper.Map<T.LicenseType>(request);
            licenseType = await _licenseTypeWriteRepository.AddAsync(licenseType);
            await _licenseTypeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateLicenseTypeResponse>(licenseType);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}