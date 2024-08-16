using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityReference.Create
{
    public class CreateOpportunityReferenceHandler : IRequestHandler<CreateOpportunityReferenceRequest, CreateOpportunityReferenceResponse>
    {
        readonly IOpportunityReferenceWriteRepository  _opportunityReferenceWriteRepository;
        readonly IMapper _mapper;
        public CreateOpportunityReferenceHandler(IOpportunityReferenceWriteRepository opportunityReferenceWriteRepository, IMapper mapper)
        {
            _opportunityReferenceWriteRepository = opportunityReferenceWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateOpportunityReferenceResponse> Handle(CreateOpportunityReferenceRequest request, CancellationToken cancellationToken)
        {
            var opportunityreference = _mapper.Map<T.OpportunityReference>(request);
            opportunityreference = await _opportunityReferenceWriteRepository.AddAsync(opportunityreference);
            await _opportunityReferenceWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateOpportunityReferenceResponse>(opportunityreference);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
