using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityStage.Update
{
    public  class UpdateOpportunityStageRequest : IRequest<UpdateOpportunityStageResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
