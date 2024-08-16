using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.ProductManufacturer.GetAll
{
    public  class GetAllProductManufacturerRequest : Pagination, IRequest<GetAllProductManufacturerResponse>
    {
    }
}
