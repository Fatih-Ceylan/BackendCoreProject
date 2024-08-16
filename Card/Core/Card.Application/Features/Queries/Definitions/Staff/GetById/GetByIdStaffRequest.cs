using MediatR;

namespace Card.Application.Features.Queries.Definitions.Staff.GetById
{
    public class GetByIdStaffRequest : IRequest<GetByIdStaffResponse>
    {
        public string Id { get; set; }
    }
}
