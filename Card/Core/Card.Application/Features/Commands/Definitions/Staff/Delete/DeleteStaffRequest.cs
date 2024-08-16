using MediatR;

namespace Card.Application.Features.Commands.Definitions.Staff.Delete
{
    public class DeleteStaffRequest : IRequest<DeleteStaffResponse>
    {
        public string Id { get; set; }
    }
}
