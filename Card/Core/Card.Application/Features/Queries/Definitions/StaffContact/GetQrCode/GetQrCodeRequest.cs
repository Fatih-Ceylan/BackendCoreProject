using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffContact.GetQrCode
{
    public class GetQrCodeRequest:IRequest<GetQrCodeResponse>
    {
        public string Id { get; set; }
    }
}
