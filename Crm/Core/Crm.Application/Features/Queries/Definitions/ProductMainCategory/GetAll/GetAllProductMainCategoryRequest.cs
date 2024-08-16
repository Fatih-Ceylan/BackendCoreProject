using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.ProductMainCategory.GetAll
{
    public class GetAllProductMainCategoryRequest : Pagination, IRequest<GetAllProductMainCategoryResponse>
    {
    }
}
