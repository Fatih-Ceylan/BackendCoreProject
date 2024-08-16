using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityReference.Create
{
    public class CreateOpportunityReferenceRequest : IRequest<CreateOpportunityReferenceResponse>
    {
        public string Name { get; set; }
    }
}
