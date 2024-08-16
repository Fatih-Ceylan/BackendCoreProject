using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityStage.GetAll
{
    public  class GetAllOpportunityStageRequest : Pagination, IRequest<GetAllOpportunityStageResponse>
    {
    }
}
