using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Update
{
    public class UpdateCompanyAddressHandler : IRequestHandler<UpdateCompanyAddressRequest, UpdateCompanyAddressResponse>
    {
        readonly ICompanyAddressReadRepository _companyAddressReadRepository;
        readonly ICompanyAddressWriteRepository _companyAddressWriteRepository;
        readonly IMapper _mapper;

        public UpdateCompanyAddressHandler(ICompanyAddressReadRepository companyAddressReadRepository, ICompanyAddressWriteRepository companyAddressWriteRepository, IMapper mapper)
        {
            _companyAddressReadRepository = companyAddressReadRepository;
            _companyAddressWriteRepository = companyAddressWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCompanyAddressResponse> Handle(UpdateCompanyAddressRequest request, CancellationToken cancellationToken)
        {
            var companyAddress = await _companyAddressReadRepository.GetByIdAsync(request.Id);
            companyAddress = _mapper.Map(request, companyAddress);

            await _companyAddressWriteRepository.SaveAsync();

            var response = _mapper.Map<UpdateCompanyAddressResponse>(companyAddress);
            response.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return response;
        }
    }
}