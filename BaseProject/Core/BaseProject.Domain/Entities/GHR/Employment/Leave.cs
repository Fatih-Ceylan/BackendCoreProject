using BaseProject.Domain.Entities.HR.Enums;

namespace BaseProject.Domain.Entities.HR.Employment
{
    public class Leave : B_BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? DayCount { get; set; }

        public double? HourCount { get; set; }

        public Guid LeaveTypeId { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid? EmployeeReplacement { get; set; }

        public LeaveType LeaveType { get; set; }

        public Employee Employee { get; set; }

        public LeaveStatusEnum LeaveStatus { get; set; }

    }
}
