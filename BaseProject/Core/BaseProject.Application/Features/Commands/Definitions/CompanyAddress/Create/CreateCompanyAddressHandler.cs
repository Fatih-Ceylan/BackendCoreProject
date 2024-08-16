using AutoMapper;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Create
{
    public class CreateCompanyAddressHandler : IRequestHandler<CreateCompanyAddressRequest, CreateCompanyAddressResponse>
    {
        readonly ICompanyAddressWriteRepository _companyAddressWriteRepository;
        readonly IMapper _mapper;

        public CreateCompanyAddressHandler(ICompanyAddressWriteRepository companyAddressWriteRepository, IMapper mapper)
        {
            _companyAddressWriteRepository = companyAddressWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCompanyAddressResponse> Handle(CreateCompanyAddressRequest request, CancellationToken cancellationToken)
        {
            var companyAddress = _mapper.Map<T.CompanyAddress>(request);
            
            companyAddress = await _companyAddressWriteRepository.AddAsync(companyAddress);
            await _companyAddressWriteRepository.SaveAsync();

            var response = _mapper.Map<CreateCompanyAddressResponse>(companyAddress);
            response.Message = CommandResponseMessage.AddedSuccess.ToString();

            return response;

        }
    }
}