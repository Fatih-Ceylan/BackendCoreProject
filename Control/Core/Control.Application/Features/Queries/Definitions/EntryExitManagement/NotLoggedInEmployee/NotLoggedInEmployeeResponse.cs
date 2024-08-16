using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.NotLoggedInEmployee
{
    public class NotLoggedInEmployeeResponse
    {
        public int TotalCount { get; set; }

        public List<LoggedInEmployeesVM> NotLoggedInEmployees { get; set; }
    }
}
