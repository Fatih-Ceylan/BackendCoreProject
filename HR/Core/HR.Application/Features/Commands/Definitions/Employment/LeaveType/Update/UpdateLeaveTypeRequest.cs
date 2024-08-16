using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.LeaveType.Update
{
    public class UpdateLeaveTypeRequest : IRequest<UpdateLeaveTypeResponse>
    {
        public string Id { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }
    }
}
