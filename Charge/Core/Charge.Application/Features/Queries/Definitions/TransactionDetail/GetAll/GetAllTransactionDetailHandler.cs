using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.VMs.Definitions;
using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.TransactionDetail.GetAll
{
    public class GetAllTransactionDetailHandler : IRequestHandler<GetAllTransactionDetailRequest, GetAllTransactionDetailResponse>
    {
        readonly ITransactionDetailReadRepository _transactionDetailReadRepository;

        public GetAllTransactionDetailHandler(ITransactionDetailReadRepository transactionDetailReadRepository)
        {
            _transactionDetailReadRepository = transactionDetailReadRepository;
        }

        public async Task<GetAllTransactionDetailResponse> Handle(GetAllTransactionDetailRequest request, CancellationToken cancellationToken)
        {
            var query = _transactionDetailReadRepository.GetAll(false)
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

                                                  }).ToList();
            return new()
            {
                TotalCount = query.Count(),
                TransactionDetails = query.ToList()
            };
        }
    }
}
