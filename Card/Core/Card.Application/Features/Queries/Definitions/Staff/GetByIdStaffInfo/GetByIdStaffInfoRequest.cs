using MediatR;

namespace Card.Application.Features.Queries.Definitions.Staff.GetByIdStaffInfo
{
    public class GetByIdStaffInfoRequest : IRequest<GetByIdStaffInfoResponse>
    {
        public string Id { get; set; }
    }
}
