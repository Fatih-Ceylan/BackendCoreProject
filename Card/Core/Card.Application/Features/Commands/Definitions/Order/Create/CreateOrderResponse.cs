using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.Order.Create
{
    public class CreateOrderResponse
    {
        public string Id { get; set; }
        public string StaffId { get; set; }
        public string AddressId { get; set; }
        public string CargoId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal? GeneralAmount { get; set; }
        public string BaseProjectCompanyId { get; set; }
        public string BaseProjectBranchId { get; set; }
        public string Message { get; set; }
    }
}
