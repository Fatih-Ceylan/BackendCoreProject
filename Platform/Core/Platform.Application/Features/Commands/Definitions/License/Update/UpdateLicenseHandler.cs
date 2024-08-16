using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;
using T = Platform.Domain.Entities.Definitions;


namespace Platform.Application.Features.Commands.Definitions.License.Update
{
    public class UpdateLicenseHandler : IRequestHandler<UpdateLicenseRequest, UpdateLicenseResponse>
    {
        readonly ILicenseWriteRepository _licenseWriteRepository;
        readonly ILicenseReadRepository _licenseReadRepository;
        readonly IMapper _mapper;

        public UpdateLicenseHandler(ILicenseWriteRepository companyWriteRepository, IMapper mapper, ILicenseReadRepository companyReadRepository)
        {
            _licenseWriteRepository = companyWriteRepository;
            _mapper = mapper;
            _licenseReadRepository = companyReadRepository;
        }

        public async Task<UpdateLicenseResponse> Handle(UpdateLicenseRequest request, CancellationToken cancellationToken)
        {
            T.License license = await _licenseReadRepository.GetByIdAsync(request.Id);
            license = _mapper.Map(request, license);
            await _licenseWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateLicenseResponse>(license);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}