using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.Order.GetDetailedListByDate
{
    public class GetDetailedListByDateRequest : Pagination, IRequest<GetDetailedListByDateResponse>
    {
        public OrderDateFilter CreatedDate { get; set; }
        public string BaseProjectCompanyId { get; set; }
        public string? BaseProjectBranchId { get; set; }
    }
}
