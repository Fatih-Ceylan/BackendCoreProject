using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Platform.Application.Features.Queries.Definitions.Order.GetAll
{
    public class GetAllOrderRequest : Pagination, IRequest<GetAllOrderResponse>
    {
        public OrderStatus OrderStatus { get; set; }

        public OrderDateFilter OrderDate { get; set; }

    }
}