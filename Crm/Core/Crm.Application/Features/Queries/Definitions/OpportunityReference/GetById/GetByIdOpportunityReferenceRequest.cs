using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityReference.GetById
{
    public  class GetByIdOpportunityReferenceRequest : IRequest<GetByIdOpportunityReferenceResponse>
    {
        public string Id { get; set; }
    }
}
