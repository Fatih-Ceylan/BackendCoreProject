using GCharge.Application.VMs.Definitions;

namespace GCharge.Application.Features.Queries.Definitions.UserTransaction.GetByUserId
{
    public class GetByIdUserTransactionResponse
    {
        public List<UserTransactionVM> UserTransactions { get; set; }
    }
}
