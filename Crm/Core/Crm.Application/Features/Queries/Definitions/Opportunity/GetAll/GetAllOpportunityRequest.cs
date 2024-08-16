using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.Opportunity.GetAll
{
    public class GetAllOpportunityRequest :Pagination, IRequest<GetAllOpportunityResponse>
    {
    }
}
