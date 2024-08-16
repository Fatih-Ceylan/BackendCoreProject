using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Employee.GetQrCode
{
    public class GetQrCodeRequest : IRequest<GetQrCodeResponse>
    {
        public string Id { get; set; }
    }
}
