using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Order.GetStaffAndQrListByOrderId
{
    public class GetStaffAndQrListByOrderIdResponse
    {
        public List<StaffAndQrListVM> StaffAndQrs { get; set; } 
    }
}
