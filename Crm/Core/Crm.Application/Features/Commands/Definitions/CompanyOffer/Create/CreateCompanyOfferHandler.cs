using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;


namespace GCrm.Application.Features.Commands.Definitions.CompanyOffer.Create
{
    public class CreateCompanyOfferHandler : IRequestHandler<CreateCompanyOfferRequest, CreateCompanyOfferResponse>
    {
        readonly ICompanyOfferWriteRepository _companyOfferWriteRepository;
        readonly IMapper _mapper;

        public CreateCompanyOfferHandler(ICompanyOfferWriteRepository companyOfferWriteRepository, IMapper mapper)
        {
            _companyOfferWriteRepository = companyOfferWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCompanyOfferResponse> Handle(CreateCompanyOfferRequest request, CancellationToken cancellationToken)
        {
            var companyoffer = _mapper.Map<T.CompanyOffer>(request);

            companyoffer = await _companyOfferWriteRepository.AddAsync(companyoffer);
            await _companyOfferWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCompanyOfferResponse>(companyoffer);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
