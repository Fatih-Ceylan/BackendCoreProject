using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityStage.Create
{
    public  class CreateOpportunityStageRequest : IRequest<CreateOpportunityStageResponse>
    {
        public string Name { get; set; }
    }
}
