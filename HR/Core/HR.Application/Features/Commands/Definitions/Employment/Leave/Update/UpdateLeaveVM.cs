using Utilities.Core.UtilityApplication.VMs;

namespace HR.Application.Features.Commands.Definitions.Employment.Leave.Update
{
    public class UpdateLeaveVM : BaseVM
    {
        public DateTime? StartDate { get; set; }

        //public virtual DateTime? StartDateHour { get; set; }

        public DateTime? EndDate { get; set; }

        //public virtual DateTime? EndDateHour { get; set; }

        public int? DayCount { get; set; }

        public float? HourCount { get; set; }

        public string? LeaveTypeId { get; set; }

        public string? LeaveTypeName { get; set; }

        public string? EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public string? EmployeeReplacement { get; set; }

        public int LeaveStatus { get; set; }
    }
}
