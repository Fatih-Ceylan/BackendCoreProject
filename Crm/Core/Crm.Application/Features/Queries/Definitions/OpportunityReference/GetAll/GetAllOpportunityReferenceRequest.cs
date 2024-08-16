using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityReference.GetAll
{
    public  class GetAllOpportunityReferenceRequest :Pagination, IRequest<GetAllOpportunityReferenceResponse>
    {
    }
}
