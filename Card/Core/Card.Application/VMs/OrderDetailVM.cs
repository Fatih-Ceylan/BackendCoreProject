using Utilities.Core.UtilityApplication.VMs;

namespace Card.Application.VMs
{
    public class OrderDetailVM : BaseVM
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public int TaxRate { get; set; }
        public string OrderId { get; set; } 
        public string CardId { get; set; } 
        public string PurchasedForStaffId { get; set; } 
        public string PurchasedFor { get; set; }
        public string CardName { get; set; }
        public string Description { get; set; }
        public string? QrBase64 { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
