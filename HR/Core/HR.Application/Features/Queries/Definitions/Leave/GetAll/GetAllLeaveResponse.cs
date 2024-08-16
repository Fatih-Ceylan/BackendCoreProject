using HR.Application.VMs.Definitions;

namespace HR.Application.Features.Queries.Definitions.Leave.GetAll
{
    public class GetAllLeaveResponse
    {
        public int TotalCount { get; set; }

        public List<LeaveVM> LeaveVMs { get; set; }
    }
}
