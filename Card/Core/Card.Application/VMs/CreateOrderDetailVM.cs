namespace Card.Application.VMs
{
    public class CreateOrderDetailVM  
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }   
        public string CardId { get; set; }
        public string PurchasedForStaffId { get; set; }
        public string Description { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
