using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.Leave.Update
{
    public class UpdateLeaveRequest : IRequest<UpdateLeaveResponse>
    {
        public string Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? DayCount { get; set; }

        public float? HourCount { get; set; }

        public string? LeaveTypeId { get; set; }

        public string? EmployeeId { get; set; }

        public string? EmployeeReplacement { get; set; }

        public int? LeaveStatus { get; set; }
    }
}
