namespace Card.Application.Features.Commands.Definitions.OrderDetail.Update
{
    public class UpdateOrderDetailResponse
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string CardId { get; set; }
        public string PurchasedForStaffId { get; set; }
        public string Description { get; set; }
        public string BaseProjectCompanyId { get; set; }
        public string BaseProjectBranchId { get; set; }
        public string Message { get; set; }
    }
}
