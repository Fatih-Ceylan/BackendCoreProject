using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.LeaveType.Delete
{
    public class DeleteLeaveTypeRequest : IRequest<DeleteLeaveTypeResponse>
    {
        public string Id { get; set; }
    }
}
