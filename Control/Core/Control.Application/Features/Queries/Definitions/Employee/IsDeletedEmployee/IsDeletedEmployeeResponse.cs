using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Employee.BringAllEmployee
{
    public class IsDeletedEmployeeResponse
    {
        public int TotalCount { get; set; }

        //public List<EmployeeVM> Employees { get; set; }
        public List<EmployeeNewBaseVM> Employees { get; set; }
    }
}
