using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.ProductModel.GetAll
{
    public  class GetAllProductModelRequest : Pagination, IRequest<GetAllProductModelResponse>
    {
    }
}
