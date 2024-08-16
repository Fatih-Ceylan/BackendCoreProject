using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.ProductSubCategory.GetAll
{
    public  class GetAllProductSubCategoryRequest : Pagination, IRequest<GetAllProductSubCategoryResponse>
    {
    }

}
