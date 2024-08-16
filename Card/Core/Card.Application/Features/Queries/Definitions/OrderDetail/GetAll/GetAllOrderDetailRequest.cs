using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.OrderDetail.GetAll
{
    public class GetAllOrderDetailRequest : Pagination, IRequest<GetAllOrderDetailResponse>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
