using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Opportunity.GetById
{
    public  class GetByIdOpportunityRequest : IRequest<GetByIdOpportunityResponse>
    {
        public string Id { get; set; }
    }
}
