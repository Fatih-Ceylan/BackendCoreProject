namespace GCharge.Application.VMs.Definitions
{
    public class UserTransactionVM
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public int TransactionId { get; set; }
        public string ChargePointId { get; set; }
        public decimal ElectricityLoadedKWh { get; set; }
        public decimal PricePerKWh { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal VatRate { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
