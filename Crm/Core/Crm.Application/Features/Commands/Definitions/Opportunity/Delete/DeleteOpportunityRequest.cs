using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Opportunity.Delete
{
    public class DeleteOpportunityRequest : IRequest<DeleteOpportunityResponse>
    {
        public string  Id { get; set; }
    }
}
