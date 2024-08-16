using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.ProductCategory.GetAll
{
    public  class GetAllProductCategoryRequest : Pagination, IRequest<GetAllProductCategoryResponse>
    {
    }
}
