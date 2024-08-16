using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.OpportunitySector.GetAll
{
    public  class GetAllOpportunitySectorRequest :Pagination, IRequest<GetAllOpportunitySectorResponse>
    {
    }
}
