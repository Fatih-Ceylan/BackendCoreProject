using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.Leave.Delete
{
    public class DeleteLeaveRequest : IRequest<DeleteLeaveResponse>
    {
        public string Id { get; set; }
    }
}
