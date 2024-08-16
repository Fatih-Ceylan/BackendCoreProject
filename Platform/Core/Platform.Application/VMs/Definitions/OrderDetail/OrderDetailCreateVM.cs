namespace Platform.Application.VMs.Definitions.OrderDetail
{
    public class OrderDetailCreateVM
    {
        public string ModuleOrderId { get; set; }

        public string ModuleOrderDetailId { get; set; }

        public string OrderId { get; set; }

        public string ProductOrServiceName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountRate { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public string? PurchasedForStaffName { get; set; }

        public string? Description { get; set; }

    }
}
