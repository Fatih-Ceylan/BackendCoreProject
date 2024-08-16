using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityStage.Update
{
    public  class UpdateOpportunityStageHandler : IRequestHandler<UpdateOpportunityStageRequest, UpdateOpportunityStageResponse>
    {
        readonly IOpportunityStageWriteRepository  _opportunityStageWriteRepository;
        readonly IOpportunityStageReadRepository  _opportunityStageReadRepository;
        readonly IMapper _mapper;

        public UpdateOpportunityStageHandler(IOpportunityStageWriteRepository  opportunityStageWriteRepository, IOpportunityStageReadRepository  opportunityStageReadRepository, IMapper mapper)
        {
            _opportunityStageWriteRepository = opportunityStageWriteRepository;
            _opportunityStageReadRepository = opportunityStageReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateOpportunityStageResponse> Handle(UpdateOpportunityStageRequest request, CancellationToken cancellationToken)
        {
            var opportunitystage = await _opportunityStageReadRepository.GetByIdAsync(request.Id);
            opportunitystage = _mapper.Map(request, opportunitystage);
            await _opportunityStageWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateOpportunityStageResponse>(opportunitystage);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
