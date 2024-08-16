using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.EmployeeEntryInAndOut
{
    public class EmployeeEntryInAndOutResponse
    {
        public int TotalCount { get; set; }
        public List<EmpEntryInOutVM> EmpEntryInOuts { get; set; }
    }
}
