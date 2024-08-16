using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityReference.Update
{
    public class UpdateOpportunityReferenceRequest:IRequest<UpdateOpportunityReferenceResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
