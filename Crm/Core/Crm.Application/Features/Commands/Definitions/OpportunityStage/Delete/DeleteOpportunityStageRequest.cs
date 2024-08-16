using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityStage.Delete
{
    public  class DeleteOpportunityStageRequest : IRequest<DeleteOpportunityStageResponse>
    {
        public string Id { get; set; }
    }
}
