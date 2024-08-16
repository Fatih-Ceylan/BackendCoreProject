using Utilities.Core.UtilityApplication.Enums;
using Utilities.Core.UtilityApplication.VMs;

namespace Card.Application.VMs
{
    public class OrderVM : BaseVM
    {
        public string AddressId { get; set; }
        public OrderStatus Status { get; set; }
        public string Description { get; set; }
        public decimal GeneralTotalAmount { get; set; }
        public string OrderNumber { get; set; }
        public decimal GeneralTotalTaxAmount { get; set; }
        public string? BuyerId { get; set; }
        public string? InvoiceId { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
