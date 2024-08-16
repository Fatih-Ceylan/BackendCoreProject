using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityReference.Delete
{
    public  class DeleteOpportunityReferenceRequest : IRequest<DeleteOpportunityReferenceResponse>
    {
        public string Id { get; set; }
    }
}
