using Card.Application.Abstractions.Services.QrCode;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.Order.GetStaffAndQrListByOrderId
{
    public class GetStaffAndQrListByOrderIdHandler : IRequestHandler<GetStaffAndQrListByOrderIdRequest, GetStaffAndQrListByOrderIdResponse>
    { 
        readonly IQrCodeService _qrCodeService;

        public GetStaffAndQrListByOrderIdHandler(IQrCodeService qrCodeService)
        { 
            _qrCodeService = qrCodeService;
        }

        public async Task<GetStaffAndQrListByOrderIdResponse> Handle(GetStaffAndQrListByOrderIdRequest request, CancellationToken cancellationToken)
        { 
            var qrData = await _qrCodeService.GenerateQrCode(request);
             
            return new()
            {
                StaffAndQrs = qrData
            };
        }
    }
}
