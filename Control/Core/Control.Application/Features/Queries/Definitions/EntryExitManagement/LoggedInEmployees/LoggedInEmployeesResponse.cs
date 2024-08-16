using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.LoggedInEmployees
{
    public class LoggedInEmployeesResponse
    {
        public int TotalCount { get; set; }

        public List<LoggedInEmployeesVM> LoggedInEmployees { get; set; }
    }
}
