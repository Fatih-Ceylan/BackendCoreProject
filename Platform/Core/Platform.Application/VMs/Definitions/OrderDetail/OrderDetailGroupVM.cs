namespace Platform.Application.VMs.Definitions.OrderDetail
{
    public class OrderDetailGroupVM
    {
        public string ProductOrServiceName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountRate { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
