using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.ProductBrand.GetAll
{
    public  class GetAllProductBrandRequest : Pagination, IRequest<GetAllProductBrandResponse>
    {
    }
}
