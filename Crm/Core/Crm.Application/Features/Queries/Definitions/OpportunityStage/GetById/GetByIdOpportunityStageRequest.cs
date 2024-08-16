using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityStage.GetById
{
    public  class GetByIdOpportunityStageRequest : IRequest<GetByIdOpportunityStageResponse>
    {
        public string Id { get; set; }
    }
}
