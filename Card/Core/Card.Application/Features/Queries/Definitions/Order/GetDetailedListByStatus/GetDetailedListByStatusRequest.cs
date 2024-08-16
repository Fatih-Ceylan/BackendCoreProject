using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.Order.GetDetailedListByStatus
{
    public class GetDetailedListByStatusRequest : Pagination, IRequest<GetDetailedListByStatusResponse>
    {
        public OrderStatus Status { get; set; }
        public OrderDateFilter CreatedDate { get; set; }
        public string  CompanyId { get; set; } 
        public string? BranchId { get; set; }
    }
}
