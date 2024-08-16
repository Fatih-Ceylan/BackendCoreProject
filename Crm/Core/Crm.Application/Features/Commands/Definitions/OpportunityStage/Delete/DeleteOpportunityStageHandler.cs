using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityStage.Delete
{
    public  class DeleteOpportunityStageHandler : IRequestHandler<DeleteOpportunityStageRequest, DeleteOpportunityStageResponse>
    {
        readonly IOpportunityStageWriteRepository  _opportunityStageWriteRepository;

        public DeleteOpportunityStageHandler(IOpportunityStageWriteRepository  opportunityStageWriteRepository)
        {
            _opportunityStageWriteRepository = opportunityStageWriteRepository;
        }

        public async Task<DeleteOpportunityStageResponse> Handle(DeleteOpportunityStageRequest request, CancellationToken cancellationToken)
        {
            await _opportunityStageWriteRepository.SoftDeleteAsync(request.Id);
            await _opportunityStageWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
