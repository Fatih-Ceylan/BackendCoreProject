using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.ProductType.GetAll
{
    public  class GetAllProductTypeRequest : Pagination, IRequest<GetAllProductTypeResponse>
    {
    }
}
