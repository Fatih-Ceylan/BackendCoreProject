using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.Product.GetAll
{
    public  class GetAllProductRequest : Pagination, IRequest<GetAllProductResponse>
    {
    }
}
