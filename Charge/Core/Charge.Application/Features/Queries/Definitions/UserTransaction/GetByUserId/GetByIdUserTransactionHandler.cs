using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.VMs.Definitions;
using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.UserTransaction.GetByUserId
{
    public class GetByIdUserTransactionHandler : IRequestHandler<GetByIdUserTransactionRequest, GetByIdUserTransactionResponse>
    {
        readonly IUserTransactionReadRepository _userTransactionReadRepository;

        public GetByIdUserTransactionHandler(IUserTransactionReadRepository userTransactionReadRepository)
        {
            _userTransactionReadRepository = userTransactionReadRepository;
        }

        public async Task<GetByIdUserTransactionResponse> Handle(GetByIdUserTransactionRequest request, CancellationToken cancellationToken)
        {
            var userTransactions = _userTransactionReadRepository
                                   .GetWhere(ut => ut.UserId == request.UserId, false)
                                   .OrderByDescending(ut => ut.CreatedDate) // CreatedDate alanına göre azalan sıralama
                                   .Select(ut => new UserTransactionVM
                                   {
                                       Id = ut.Id.ToString(),
                                       UserId = ut.UserId,
                                       UserName = ut.User != null ? ut.User.UserName : string.Empty,
                                       TransactionId = ut.TransactionId,
                                       ChargePointId = ut.ChargePointId,
                                       ElectricityLoadedKWh = ut.ElectricityLoadedKWh,
                                       PricePerKWh = ut.PricePerKWh,
                                       TotalAmount = ut.TotalAmount,
                                       VatRate = ut.VatRate,
                                       VatAmount = ut.VatAmount,
                                       GrandTotal = ut.GrandTotal,
                                       CreatedDate = ut.CreatedDate
                                   }).ToList();

            return new()
            {
                UserTransactions = userTransactions
            };
        }
    }
}
