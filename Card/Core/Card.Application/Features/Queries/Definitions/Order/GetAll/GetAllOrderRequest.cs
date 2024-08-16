using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.Order.GetAll
{
    public class GetAllOrderRequest : Pagination, IRequest<GetAllOrderResponse>
    {
        public string CompanyId { get; set; }

        public string BranchId { get; set; }
    }
}