using GCharge.Application.VMs.Definitions;

namespace GCharge.Application.Features.Queries.Definitions.UserTransaction.GetAll
{
    public class GetAllUserTransactionResponse
    {
        public int TotalCount { get; set; }
        public List<UserTransactionVM>  UserTransactions{ get; set; }
    }
}
