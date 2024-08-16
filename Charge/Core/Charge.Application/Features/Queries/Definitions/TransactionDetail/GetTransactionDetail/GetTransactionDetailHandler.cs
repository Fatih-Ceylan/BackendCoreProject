using GCharge.Application.Features.Queries.Definitions.TransactionDetail.GetByTransaction;
using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.VMs.Definitions;
using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.TransactionDetail.GetByConnectorId
{
    public class GetTransactionDetailHandler : IRequestHandler<GetTransactionDetailRequest, GetTransactionDetailResponse>
    {
        readonly ITransactionDetailReadRepository _transactionDetailReadRepository;

        public GetTransactionDetailHandler(ITransactionDetailReadRepository transactionDetailReadRepository)
        {
            _transactionDetailReadRepository = transactionDetailReadRepository;
        }

        public async Task<GetTransactionDetailResponse> Handle(GetTransactionDetailRequest request, CancellationToken cancellationToken)
        {
            var transactionDetail = _transactionDetailReadRepository
                            .GetWhere(td => td.ConnectorId == request.ConnectorId && td.ChargePointId == request.ChargePointId, false)
                            .OrderBy(td => td.TransactionId)
                            .Select(td => new TransactionDetailVM
                            {
                                Id = td.Id.ToString(),
                                TransactionId = td.TransactionId,
                                ChargePointId = td.ChargePointId,
                                ConnectorId = td.ConnectorId,
                                CurrentChargeKW = td.CurrentChargeKW,
                                MeterKWH = td.MeterKWH,
                                StateOfCharge = td.StateOfCharge,
                                Timestamp = td.Timestamp
                            }).LastOrDefault();

            return new()
            {
                TransactionDetail = transactionDetail
            };
        }
    }
}
