using HR.Application.VMs.Definitions;

namespace HR.Application.Features.Queries.Definitions.LeaveType.GetAll
{
    public class GetAllLeaveTypeResponse
    {
        public int TotalCount { get; set; }

        public List<LeaveTypeVM> LeaveTypeVMs { get; set; }
    }
}
