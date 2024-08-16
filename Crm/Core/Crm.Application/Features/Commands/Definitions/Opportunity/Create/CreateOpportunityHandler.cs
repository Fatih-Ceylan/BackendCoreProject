using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;

namespace GCrm.Application.Features.Commands.Definitions.Opportunity.Create
{
    public class CreateOpportunityHandler : IRequestHandler<CreateOpportunityRequest, CreateOpportunityResponse>
    {
        readonly IOpportunityWriteRepository _opportunityWriteRepository;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IMapper _mapper;

        public CreateOpportunityHandler(IOpportunityWriteRepository opportunityWriteRepository, ICompanyReadRepository companyReadRepository, IMapper  mapper)
        {
            _opportunityWriteRepository = opportunityWriteRepository;
            _companyReadRepository = companyReadRepository;
            _mapper = mapper;
        }

        public async Task<CreateOpportunityResponse> Handle(CreateOpportunityRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }

            var opportunity = _mapper.Map<T.Opportunity>(request);
            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                opportunity.CompanyId = mainCompanyId;
            }
         
            opportunity = await _opportunityWriteRepository.AddAsync(opportunity);
            await _opportunityWriteRepository.SaveAsync();

          

            var createdResponse = _mapper.Map<CreateOpportunityResponse>(opportunity);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
