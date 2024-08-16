using Card.Application.Features.Queries.Definitions.Order.GetStaffAndQrListByOrderId;
using Card.Application.VMs;

namespace Card.Application.Abstractions.Services.QrCode
{
    public interface IQrCodeService
    {
        Task<List<StaffAndQrListVM>> GenerateQrCode (GetStaffAndQrListByOrderIdRequest request);
    }
}
