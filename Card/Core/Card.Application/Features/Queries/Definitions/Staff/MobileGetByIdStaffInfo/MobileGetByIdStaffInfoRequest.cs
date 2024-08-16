using MediatR;

namespace Card.Application.Features.Queries.Definitions.Staff.MobileGetByIdStaffInfo
{
    public class MobileGetByIdStaffInfoRequest : IRequest<MobileGetByIdStaffInfoResponse>
    {
        public string Id { get; set; }
        public string Token { get; set; }
    }
}
