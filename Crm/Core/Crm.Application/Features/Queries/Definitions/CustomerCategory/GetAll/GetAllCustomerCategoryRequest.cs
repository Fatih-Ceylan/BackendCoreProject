using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerCategory.GetAll
{
    public class GetAllCustomerCategoryRequest : Pagination, IRequest<GetAllCustomerCategoryResponse>
    {
    }
}
