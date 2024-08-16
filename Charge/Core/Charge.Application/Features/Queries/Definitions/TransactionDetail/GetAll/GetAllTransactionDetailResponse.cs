using GCharge.Application.VMs.Definitions;

namespace GCharge.Application.Features.Queries.Definitions.TransactionDetail.GetAll
{
    public class GetAllTransactionDetailResponse
    {
        public int TotalCount { get; set; }

        public List<TransactionDetailVM> TransactionDetails { get; set; }
    }
}
