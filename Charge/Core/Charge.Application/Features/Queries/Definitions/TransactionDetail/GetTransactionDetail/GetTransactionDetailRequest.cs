using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.TransactionDetail.GetByTransaction
{
    public class GetTransactionDetailRequest : IRequest<GetTransactionDetailResponse>
    {
        public string ChargePointId { get; set; }
        public int ConnectorId { get; set; }
    }
}
