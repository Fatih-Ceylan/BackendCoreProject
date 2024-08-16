using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityStage.Create
{
    public  class CreateOpportunityStageHandler : IRequestHandler<CreateOpportunityStageRequest, CreateOpportunityStageResponse>
    {
        readonly IOpportunityStageWriteRepository  _opportunityStageWriteRepository;
        readonly IMapper _mapper;

        public CreateOpportunityStageHandler(IOpportunityStageWriteRepository  opportunityStageWriteRepository, IMapper mapper)
        {
            _opportunityStageWriteRepository = opportunityStageWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateOpportunityStageResponse> Handle(CreateOpportunityStageRequest request, CancellationToken cancellationToken)
        {
            var opportunitystage = _mapper.Map<T.OpportunityStage>(request);
            opportunitystage = await _opportunityStageWriteRepository.AddAsync(opportunitystage);
            await _opportunityStageWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateOpportunityStageResponse>(opportunitystage);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
