using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.VMs.Definitions;
using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.UserTransaction.GetAll
{
    public class GetAllUserTransactionHandler : IRequestHandler<GetAllUserTransactionRequest, GetAllUserTransactionResponse>
    {
        readonly IUserTransactionReadRepository _userTransactionReadRepository;

        public GetAllUserTransactionHandler(IUserTransactionReadRepository userTransactionReadRepository)
        {
            _userTransactionReadRepository = userTransactionReadRepository;
        }

        public async Task<GetAllUserTransactionResponse> Handle(GetAllUserTransactionRequest request, CancellationToken cancellationToken)
        {
            var query = _userTransactionReadRepository.GetAll(false)
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
                                                       VatRate= ut.VatRate,
                                                       VatAmount = ut.VatAmount,
                                                       GrandTotal = ut.GrandTotal,
                                                       CreatedDate = ut.CreatedDate
                                                   }).ToList();

            return new GetAllUserTransactionResponse
            {
                TotalCount = query.Count,
                UserTransactions = query
            };
        }

    }
}